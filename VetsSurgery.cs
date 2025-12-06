using System;
using System.IO;

namespace VetsSurgeryApp
{
    class VetsSurgery
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Vets Surgery Appointment System ===\n");

            // Get filename and path
            string fileName = GetFileName();

            // Create 2D array to store appointments (time and customer ID)
            string[,] appointments = new string[10, 2]; // 10 slots, 2 columns (time, customerID)

            // Load all appointments from file
            LoadAppointments(fileName, appointments);

            // Display all appointments
            DisplayAppointments(appointments);

            // Find first available appointment
            FindFirstAvailableSlot(appointments);
        }

        /// <summary>
        /// Subroutine to get the filename and path for the appointments.csv file
        /// </summary>
        static string GetFileName()
        {
            // Default filename
            string fileName = "appointments.csv";

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
            Console.Write("Please enter the full path to appointments.csv: ");
            string userPath = Console.ReadLine();

            return userPath;
        }

        /// <summary>
        /// Subroutine to get all appointments from the file and store them in the 2D array
        /// </summary>
        static void LoadAppointments(string fileName, string[,] appointments)
        {
            try
            {
                // Read all lines from the CSV file
                string[] lines = File.ReadAllLines(fileName);

                int row = 0;
                foreach (string line in lines)
                {
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Stop if we've filled all 10 slots
                    if (row >= 10)
                        break;

                    // Split by comma to get time and customer ID
                    string[] parts = line.Split(',');

                    if (parts.Length >= 2)
                    {
                        // Store time in column 0
                        appointments[row, 0] = parts[0].Trim();

                        // Store customer ID in column 1 (empty string if no booking)
                        appointments[row, 1] = parts[1].Trim();
                    }
                    else if (parts.Length == 1)
                    {
                        // Only time provided, no customer ID
                        appointments[row, 0] = parts[0].Trim();
                        appointments[row, 1] = "";
                    }

                    row++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        /// <summary>
        /// Display all appointment slots with their status
        /// </summary>
        static void DisplayAppointments(string[,] appointments)
        {
            Console.WriteLine("Current Appointment Schedule:");
            Console.WriteLine("─────────────────────────────────────────");
            Console.WriteLine($"{"Slot",-6} {"Time",-12} {"Customer ID",-15} {"Status",-10}");
            Console.WriteLine("─────────────────────────────────────────");

            for (int i = 0; i < appointments.GetLength(0); i++)
            {
                string time = appointments[i, 0] ?? "";
                string customerId = appointments[i, 1] ?? "";
                string status = string.IsNullOrWhiteSpace(customerId) ? "Available" : "Booked";

                Console.WriteLine($"{i + 1,-6} {time,-12} {customerId,-15} {status,-10}");
            }

            Console.WriteLine("─────────────────────────────────────────\n");
        }

        /// <summary>
        /// Subroutine to use linear search to find the first appointment with a blank customer ID
        /// Returns the row index of the array
        /// </summary>
        static void FindFirstAvailableSlot(string[,] appointments)
        {
            Console.WriteLine("Searching for first available appointment slot...\n");

            // Linear search through the appointments array
            int firstAvailableIndex = LinearSearchFirstAvailable(appointments);

            if (firstAvailableIndex != -1)
            {
                // Available slot found
                string appointmentTime = appointments[firstAvailableIndex, 0];
                Console.WriteLine($"There is an appointment available!");
                Console.WriteLine($"Time: {appointmentTime}");
                Console.WriteLine($"Slot Number: {firstAvailableIndex + 1}");
            }
            else
            {
                // No available slots
                Console.WriteLine("All appointments are booked.");
            }
        }

        /// <summary>
        /// Linear search subroutine to find the first available slot (blank customer ID)
        /// Returns the row index if found, or -1 if all slots are booked
        /// </summary>
        static int LinearSearchFirstAvailable(string[,] appointments)
        {
            // Search through each row
            for (int i = 0; i < appointments.GetLength(0); i++)
            {
                // Check if customer ID is blank (column 1)
                string customerId = appointments[i, 1] ?? "";

                if (string.IsNullOrWhiteSpace(customerId))
                {
                    // Found first available slot
                    return i;
                }
            }

            // No available slots found
            return -1;
        }
    }
}
