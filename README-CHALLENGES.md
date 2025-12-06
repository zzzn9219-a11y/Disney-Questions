# Challenge 5 Solutions - Phone Directory & Vets Surgery

## Overview

This folder contains solutions for two programming challenges that demonstrate:
- **File handling** (reading CSV files)
- **Data structures** (records, lists, and 2D arrays)
- **Search algorithms** (binary search and linear search)
- **Subroutines** (modular code organization)

## Files in This Folder

### Challenge 1: Phone Directory
- **PhoneDirectory.cs** - Main program (binary search implementation)
- **PhoneDirectory-OVERVIEW.md** - Simple beginner-friendly explanation
- **phonedirectory.csv** - Sample contact data

### Challenge 2: Vets Surgery
- **VetsSurgery.cs** - Main program (linear search implementation)
- **VetsSurgery-OVERVIEW.md** - Simple beginner-friendly explanation
- **appointments.csv** - Sample appointment data

### Original Challenge
- **Program.cs** - Disney Quiz (original challenge solution)

## How to Run the Programs

### Option 1: Using Visual Studio 2022

#### For Phone Directory:
1. Open `challenge5.csproj` in a text editor or VS
2. Make sure this line says:
   ```xml
   <StartupObject>PhoneDirectoryApp.PhoneDirectory</StartupObject>
   ```
3. Save and rebuild (Ctrl+Shift+B)
4. Press F5 or click Run
5. Make sure `phonedirectory.csv` is in the project folder

#### For Vets Surgery:
1. Open `challenge5.csproj`
2. Change the line to:
   ```xml
   <StartupObject>VetsSurgeryApp.VetsSurgery</StartupObject>
   ```
3. Save and rebuild (Ctrl+Shift+B)
4. Press F5 or click Run
5. Make sure `appointments.csv` is in the project folder

📖 **See SWITCH-PROGRAMS.md for detailed switching instructions**

### Option 2: Using Command Line

```bash
# Navigate to the project folder
cd tasks/challenge5

# For Phone Directory:
# Edit challenge5.csproj to set StartupObject to PhoneDirectoryApp.PhoneDirectory
dotnet run

# For Vets Surgery:
# Edit challenge5.csproj to set StartupObject to VetsSurgeryApp.VetsSurgery
dotnet run
```

## What Each Program Does

### Phone Directory
- Loads contacts from a CSV file (surname, firstname, phone number)
- Displays all contacts in a formatted table
- Lets you search for a contact by surname
- Uses **binary search** for fast searching
- Shows phone number or "not found" message

**Key Concepts:**
- Record structures
- Lists
- Binary search algorithm
- String comparison
- File reading

### Vets Surgery
- Loads appointment bookings from a CSV file (time, customer ID)
- Displays all 10 appointment slots
- Shows which slots are booked and which are available
- Finds the first available appointment slot
- Uses **linear search** to find first available

**Key Concepts:**
- 2D arrays
- Linear search algorithm
- Working with rows and columns
- Checking for empty values
- File reading

## Learning Path

### Start Here: Read the Overviews
1. Read **PhoneDirectory-OVERVIEW.md** first
2. Then read **VetsSurgery-OVERVIEW.md**

These files explain:
- What the program does
- How it works step by step
- What each part of the code means
- Examples with visual diagrams
- Key concepts explained simply

### Next: Study the Code
1. Open **PhoneDirectory.cs** and follow along with the overview
2. Open **VetsSurgery.cs** and follow along with the overview

### Finally: Run and Test
1. Run each program
2. Try different searches
3. Modify the CSV files and see what happens
4. Experiment with the code

## Sample Data

### phonedirectory.csv
```
Anderson, Riley, +44 555-3456
Brown, Charlie, +44 555-9876
Davis, Emily, +44 555-8765
Harris, Henry, +44 555-3456
Johnson, Alice, +44 555-1234
Miller, David, +44 555-4321
Robinson, Kelly, +44 555-9876
Smith, Bob, +44 555-5678
Taylor, Grace, +44 555-7890
Turner, Isabella, +44 555-6789
White, Frank, +44 555-2345
```

### appointments.csv
```
09:00:00,5877RC
09:30:00,9655AS
10:00:00,
10:30:00,8754TT
11:00:00,
11:30:00,8745SD
13:00:00,9635GH
13:30:00,
14:00:00,9874PL
14:30:00,9658SV
```

## Key Differences Between the Two Programs

| Feature | Phone Directory | Vets Surgery |
|---------|----------------|--------------|
| **Data Structure** | List (dynamic size) | 2D Array (fixed size) |
| **Search Algorithm** | Binary Search | Linear Search |
| **Data Must Be Sorted?** | Yes (for binary search) | No |
| **What We Find** | Specific surname match | First available slot |
| **Speed** | Very fast (O(log n)) | Slower but simple (O(n)) |
| **Complexity** | More complex | Simpler |

## Challenge Requirements Met

### Phone Directory ✓
- [x] Creates a record structure for contacts
- [x] Creates a list to store all contacts
- [x] Uses subroutine to get filename and path
- [x] Uses subroutine to load all contacts from file
- [x] Asks user for surname to search
- [x] Uses binary search to find contact
- [x] Returns list index or -1 if not found
- [x] Outputs phone number or error message

### Vets Surgery ✓
- [x] Creates 2D array for appointments
- [x] Uses subroutine to get filename and path
- [x] Uses subroutine to load all appointments from file
- [x] Uses linear search to find first available slot
- [x] Returns row index of the array
- [x] Outputs appointment time or "all booked" message

## Extending These Programs

### Ideas for Phone Directory:
- Add ability to add new contacts
- Allow searching by firstname
- Allow editing contact information
- Add ability to delete contacts
- Save changes back to the CSV file

### Ideas for Vets Surgery:
- Add ability to book an appointment
- Allow canceling appointments
- Show all available slots (not just first)
- Add customer name in addition to ID
- Save changes back to the CSV file

## OCR A-Level Topics Covered

These programs demonstrate key topics from the OCR syllabus:

**2.1 Programming Techniques:**
- File handling
- Records
- Lists and arrays
- Subroutines
- Input validation
- String manipulation

**2.2 Standard Algorithms:**
- Binary search
- Linear search
- Sorting (for binary search prerequisite)

**1.4.1 Data Types:**
- Records/structures
- Arrays (1D and 2D)
- Strings

## Tips for Understanding

1. **Don't rush** - Read the overviews carefully
2. **Visualize** - Draw the data structures on paper
3. **Trace through** - Follow the code line by line with example data
4. **Experiment** - Change values and see what happens
5. **Ask questions** - If something is confusing, research or ask for help

## Common Mistakes to Avoid

1. **Forgetting to sort before binary search** - Binary search only works on sorted data!
2. **Array index confusion** - Remember arrays start at 0, not 1
3. **Off-by-one errors** - Be careful with loop boundaries
4. **Not handling empty values** - Always check for null or empty strings
5. **File path issues** - Make sure CSV files are in the right location

## Next Steps

After mastering these programs:
1. Try implementing the extension ideas
2. Create your own similar programs with different data
3. Combine binary and linear search in one program
4. Learn about other search algorithms (interpolation search, etc.)
5. Study time complexity and efficiency

## Questions to Test Your Understanding

1. Why does binary search require sorted data?
2. When would linear search be better than binary search?
3. What's the difference between a List and an array?
4. How do you access an element in a 2D array?
5. Why do we use subroutines instead of putting all code in Main?
6. What does `string.IsNullOrWhiteSpace()` check for?
7. How does `Split(',')` work on a string?

If you can answer these questions, you understand the core concepts!

## Resources

- **OCR Specification**: Section 2.1 (Programming Techniques) and 2.2 (Standard Algorithms)
- **C# Documentation**: docs.microsoft.com/en-us/dotnet/csharp/
- **Algorithm Visualization**: visualgo.net (great for seeing how searches work)

Good luck with your learning! 🎓
