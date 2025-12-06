# Phone Directory - Simple Overview

## What Does This Program Do?

This program is like a digital phone book. It reads contact information from a file and lets you search for people by their surname (last name).

## How It Works - Step by Step

### 1. **Starting the Program**
   - The program says "Hello" with a title
   - It looks for a file called `phonedirectory.csv`

### 2. **Loading Contacts**
   - Opens the CSV file (like a simple spreadsheet)
   - Reads each line which has: Surname, Firstname, Phone Number
   - Example: `Anderson, Riley, +44 555-3456`
   - Stores all contacts in a **list** (like a container that holds many contacts)
   - **Sorts** the list alphabetically by surname (A-Z)

### 3. **Displaying All Contacts**
   - Shows a nice table with all contacts
   - Each contact has a number, surname, firstname, and phone number

### 4. **Searching for a Contact**
   - Asks you to type a surname you want to find
   - Uses **binary search** to find it quickly
   - Shows the phone number if found
   - Shows "not found" message if the person isn't in the directory

## Important Parts Explained

### What is a Record?
```csharp
public record Contact(string Surname, string Firstname, string PhoneNumber);
```
- A **record** is like a container that holds related information together
- Think of it like a contact card with three boxes:
  - Box 1: Surname (last name)
  - Box 2: Firstname (first name)
  - Box 3: PhoneNumber

### What is a List?
```csharp
List<Contact> contacts = new List<Contact>();
```
- A **list** is like a shopping bag that can hold many items
- In this case, it holds many Contact records
- We can add contacts, search through them, and sort them

### What is Binary Search?
Binary search is a **fast way to find something** in a sorted list:

1. Look at the **middle** item
2. Is it what you're looking for?
   - **Yes?** → Found it! ✓
   - **No?** → Continue...
3. Is what you're looking for **before** or **after** the middle item?
   - **Before?** → Only search the left half
   - **After?** → Only search the right half
4. Repeat until found (or not found)

**Example:**
Looking for "Miller" in: Anderson, Brown, Davis, Harris, Johnson, Miller, Robinson, Smith, Taylor, Turner, White

```
Step 1: Check middle (Johnson)
        "Miller" comes AFTER "Johnson"
        → Search right half: Miller, Robinson, Smith, Taylor, Turner, White

Step 2: Check middle of right half (Smith)
        "Miller" comes BEFORE "Smith"
        → Search left half: Miller, Robinson

Step 3: Check middle (Miller or Robinson)
        Found "Miller"! ✓
```

This is much faster than checking every single name one by one!

### How File Reading Works
```csharp
string[] lines = File.ReadAllLines(fileName);
```
- Opens the CSV file
- Reads all lines at once
- Each line becomes one item in an array (numbered list)

```csharp
string[] parts = line.Split(',');
```
- Takes one line: `Anderson, Riley, +44 555-3456`
- Splits it at each comma
- Creates array: `["Anderson", " Riley", " +44 555-3456"]`
- `parts[0]` = "Anderson"
- `parts[1]` = " Riley"
- `parts[2]` = " +44 555-3456"

### String Comparison for Binary Search
```csharp
int comparison = string.Compare(contacts[middle].Surname, targetSurname,
                                StringComparison.OrdinalIgnoreCase);
```
- Compares two surnames alphabetically
- `OrdinalIgnoreCase` means: don't care about CAPITAL or small letters
- Returns:
  - **0** if they're the same → Found it!
  - **negative number** if first name comes before second → Search left
  - **positive number** if first name comes after second → Search right

## The Subroutines (Functions)

### 1. `GetFileName()`
**What it does:** Finds the phonedirectory.csv file
- First looks in the current folder
- Then looks in the project folder
- If not found, asks you to type the location

### 2. `LoadContacts(fileName)`
**What it does:** Reads all contacts from the file
- Opens the CSV file
- Reads each line
- Splits each line into surname, firstname, phone number
- Creates a Contact record for each person
- Adds all contacts to the list
- Sorts the list alphabetically by surname
- Returns the complete list

### 3. `DisplayAllContacts(contacts)`
**What it does:** Shows all contacts in a table
- Creates a nice formatted table
- Shows each contact with a number
- Makes it easy to see everyone

### 4. `SearchContact(contacts)`
**What it does:** Lets you search for someone
- Asks for a surname to search
- Calls the binary search function
- Shows the result (found or not found)

### 5. `BinarySearchBySurname(contacts, targetSurname)`
**What it does:** Fast search algorithm
- Uses binary search method
- Returns the position number (index) if found
- Returns -1 if not found

## Example Run

```
=== Phone Directory ===

All Contacts:
─────────────────────────────────────────────────
#    Surname         Firstname       Phone Number
─────────────────────────────────────────────────
1    Anderson        Riley           +44 555-3456
2    Brown           Charlie         +44 555-9876
3    Davis           Emily           +44 555-8765
4    Harris          Henry           +44 555-3456
5    Johnson         Alice           +44 555-1234
6    Miller          David           +44 555-4321
7    Robinson        Kelly           +44 555-9876
8    Smith           Bob             +44 555-5678
9    Taylor          Grace           +44 555-7890
10   Turner          Isabella        +44 555-6789
11   White           Frank           +44 555-2345
─────────────────────────────────────────────────

Enter surname you are looking for: Taylor

Contact found!
Name: Grace Taylor
Phone Number: +44 555-7890
```

## Key Learning Points

1. **Records** group related data together
2. **Lists** can hold many items of the same type
3. **CSV files** store data with commas separating values
4. **Binary search** is much faster than linear search (checking one by one)
5. **Sorting** the list first is required for binary search to work
6. **Subroutines** break big problems into smaller, manageable pieces
7. **String comparison** lets us compare text alphabetically

## Why Sort Before Binary Search?

Binary search only works if the list is in order (sorted)!

**Think of it like a dictionary:**
- Words are in alphabetical order
- You can quickly find "zebra" by opening near the end
- You know "zebra" won't be at the beginning

**If the dictionary wasn't sorted:**
- Words would be random
- You'd have to check every single page
- Binary search wouldn't work!

Same with our phone directory - we sort by surname so binary search works correctly.
