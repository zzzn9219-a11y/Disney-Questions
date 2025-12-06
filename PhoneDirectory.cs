using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneDirectoryApp
{
    // Record structure to store contact details
    public record Contact(string Surname, string Firstname, string PhoneNumber);

    class PhoneDirectory
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Phone Directory ===\n");

            // Get filename and path
            string fileName = GetFileName();

            // Load all contacts from file
            List<Contact> contacts = LoadContacts(fileName);

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found in the phone directory.");
                return;
            }

            // Display all contacts
            DisplayAllContacts(contacts);

            // Search for a contact
            SearchContact(contacts);
        }

        /// <summary>
        /// Subroutine to get the filename and path for the phonedirectory.csv file
        /// </summary>
        static string GetFileName()
        {
            // Default filename
            string fileName = "phonedirectory.csv";

            // Check if file exists in current directory
            if (File.Exists(fileName))
            {
                return fileName;
            }

            // Check in project directory (go up from bin/Debug/net6.0 to project root)
            string projectPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", fileName);
            if (File.Exists(projectPath))
            {
                return Path.GetFullPath(projectPath);
            }

            // Prompt user for file path if not found
            Console.WriteLine($"File '{fileName}' not found in current or project directory.");
            Console.Write("Please enter the full path to phonedirectory.csv: ");
            string userPath = Console.ReadLine();

            return userPath;
        }

        /// <summary>
        /// Subroutine to get all contacts from the file and store them in a list
        /// </summary>
        static List<Contact> LoadContacts(string fileName)
        {
            List<Contact> contacts = new List<Contact>();

            try
            {
                // Read all lines from the CSV file
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Split by comma to get surname, firstname, phone number
                    string[] parts = line.Split(',');

                    if (parts.Length >= 3)
                    {
                        string surname = parts[0].Trim();
                        string firstname = parts[1].Trim();
                        string phoneNumber = parts[2].Trim();

                        // Only add if all fields have data
                        if (!string.IsNullOrWhiteSpace(surname) &&
                            !string.IsNullOrWhiteSpace(firstname) &&
                            !string.IsNullOrWhiteSpace(phoneNumber))
                        {
                            contacts.Add(new Contact(surname, firstname, phoneNumber));
                        }
                    }
                }

                // Sort contacts by surname for binary search to work
                contacts.Sort((a, b) => string.Compare(a.Surname, b.Surname, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return contacts;
        }

        /// <summary>
        /// Display all contacts in a numbered list
        /// </summary>
        static void DisplayAllContacts(List<Contact> contacts)
        {
            Console.WriteLine("All Contacts:");
            Console.WriteLine("─────────────────────────────────────────────────");
            Console.WriteLine($"{"#",-4} {"Surname",-15} {"Firstname",-15} {"Phone Number",-20}");
            Console.WriteLine("─────────────────────────────────────────────────");

            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"{i + 1,-4} {contacts[i].Surname,-15} {contacts[i].Firstname,-15} {contacts[i].PhoneNumber,-20}");
            }

            Console.WriteLine("─────────────────────────────────────────────────\n");
        }

        /// <summary>
        /// Ask user for surname and search for contact using binary search
        /// </summary>
        static void SearchContact(List<Contact> contacts)
        {
            Console.Write("Enter surname you are looking for: ");
            string searchSurname = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(searchSurname))
            {
                Console.WriteLine("Invalid surname entered.");
                return;
            }

            // Use binary search to find the contact
            int index = BinarySearchBySurname(contacts, searchSurname);

            if (index != -1)
            {
                // Contact found
                Contact foundContact = contacts[index];
                Console.WriteLine($"\nContact found!");
                Console.WriteLine($"Name: {foundContact.Firstname} {foundContact.Surname}");
                Console.WriteLine($"Phone Number: {foundContact.PhoneNumber}");
            }
            else
            {
                // Contact not found
                Console.WriteLine($"\nThis contact is not in the phone directory");
            }
        }

        /// <summary>
        /// Binary search subroutine to find a contact by surname
        /// Returns the list index if found, or -1 if not found
        /// </summary>
        static int BinarySearchBySurname(List<Contact> contacts, string targetSurname)
        {
            int left = 0;
            int right = contacts.Count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                // Compare strings (case-insensitive)
                int comparison = string.Compare(contacts[middle].Surname, targetSurname, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    // Found the contact
                    return middle;
                }
                else if (comparison < 0)
                {
                    // Target is in the right half
                    left = middle + 1;
                }
                else
                {
                    // Target is in the left half
                    right = middle - 1;
                }
            }

            // Contact not found
            return -1;
        }
    }
}
