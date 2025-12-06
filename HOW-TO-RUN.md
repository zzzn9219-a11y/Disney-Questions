# How to Run the Challenge Programs

## Quick Start Guide

Both programs are ready to run! Here's how to test them.

## Prerequisites

- Visual Studio 2022 (recommended for Windows)
- OR .NET SDK 7.0+ (for command line on any platform)
- The CSV files must be in the same folder as the programs

## Method 1: Visual Studio 2022 (Easiest)

### Running Phone Directory:

1. **Open the solution in Visual Studio 2022**
2. **Create a new C# Console Project** or use this one
3. **Replace the contents of Program.cs** with the code from `PhoneDirectory.cs`
4. **Copy `phonedirectory.csv`** to your project folder
5. **Press F5** to run

### Running Vets Surgery:

1. **Replace the contents of Program.cs** with the code from `VetsSurgery.cs`
2. **Copy `appointments.csv`** to your project folder
3. **Press F5** to run

## Method 2: Command Line (.NET CLI)

### For Phone Directory:

```bash
# Navigate to the folder
cd tasks/challenge5

# Make sure phonedirectory.csv is here
ls phonedirectory.csv

# Create temporary project for Phone Directory
mkdir PhoneDirectoryTest
cd PhoneDirectoryTest
dotnet new console
cp ../PhoneDirectory.cs Program.cs
cp ../phonedirectory.csv .

# Run it
dotnet run
```

### For Vets Surgery:

```bash
# Navigate to the folder
cd tasks/challenge5

# Make sure appointments.csv is here
ls appointments.csv

# Create temporary project for Vets Surgery
mkdir VetsSurgeryTest
cd VetsSurgeryTest
dotnet new console
cp ../VetsSurgery.cs Program.cs
cp ../appointments.csv .

# Run it
dotnet run
```

## Expected Output

### Phone Directory - Example Session

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

### Testing Different Searches:

**Successful search:**
```
Enter surname you are looking for: Miller
Contact found!
Name: David Miller
Phone Number: +44 555-4321
```

**Failed search:**
```
Enter surname you are looking for: Jones
This contact is not in the phone directory
```

**Case-insensitive search:**
```
Enter surname you are looking for: SMITH
Contact found!
Name: Bob Smith
Phone Number: +44 555-5678
```

### Vets Surgery - Example Session

```
=== Vets Surgery Appointment System ===

Current Appointment Schedule:
─────────────────────────────────────────
Slot   Time         Customer ID     Status
─────────────────────────────────────────
1      09:00:00     5877RC          Booked
2      09:30:00     9655AS          Booked
3      10:00:00                     Available
4      10:30:00     8754TT          Booked
5      11:00:00                     Available
6      11:30:00     8745SD          Booked
7      13:00:00     9635GH          Booked
8      13:30:00                     Available
9      14:00:00     9874PL          Booked
10     14:30:00     9658SV          Booked
─────────────────────────────────────────

Searching for first available appointment slot...

There is an appointment available!
Time: 10:00:00
Slot Number: 3
```

## Troubleshooting

### Problem: "File not found" error

**Solution:** Make sure the CSV file is in the correct location:
- For Visual Studio: Copy to project root folder (where .csproj file is)
- For command line: Copy to the same folder as your compiled program

### Problem: "Cannot find namespace" errors

**Solution:** Make sure you have all the required `using` statements at the top:
```csharp
using System;
using System.Collections.Generic;
using System.IO;
```

### Problem: CSV file opens in Excel instead of being read

**Solution:** This is normal. The program reads the CSV file programmatically. Just make sure:
1. Excel is closed when running the program
2. The file path is correct
3. The file has the right format (comma-separated values)

### Problem: Program compiles but crashes on startup

**Possible causes:**
1. CSV file is missing
2. CSV file is in wrong format
3. File path is incorrect

**Debug steps:**
1. Check the CSV file exists
2. Open CSV in Notepad to verify format
3. Try entering the full file path when prompted

## Testing Tips

### For Phone Directory:

Test these scenarios:
1. Search for existing contact (e.g., "Taylor") ✓
2. Search for non-existing contact (e.g., "Jones") ✗
3. Search with different case (e.g., "SMITH" or "smith") ✓
4. Search for first name in list (e.g., "Anderson") ✓
5. Search for last name in list (e.g., "White") ✓

### For Vets Surgery:

Test these scenarios:
1. Run with sample data (3 available slots) ✓
2. Modify CSV to have no available slots ✗
3. Modify CSV to have first slot available ✓
4. Add more appointment times
5. Remove appointment times

## Modifying the CSV Files

### Phone Directory Format:
```
Surname, Firstname, PhoneNumber
Anderson, Riley, +44 555-3456
```

**Rules:**
- Three columns separated by commas
- Can have spaces after commas
- Must have all three values

**Try adding:**
```
Jones, Sarah, +44 555-9999
```

### Appointments Format:
```
Time,CustomerID
09:00:00,5877RC
10:00:00,
```

**Rules:**
- Two columns separated by comma
- Time in HH:MM:SS format
- Customer ID can be empty (available slot)
- No space after comma for empty values

**Try modifying:**
```
15:00:00,        ← Available slot at 3 PM
15:30:00,ABCD123 ← Booked slot at 3:30 PM
```

## Understanding the Code Flow

### Phone Directory Flow:
```
Start
  ↓
Find CSV file (GetFileName)
  ↓
Load all contacts into List (LoadContacts)
  ↓
Sort contacts by surname
  ↓
Display all contacts (DisplayAllContacts)
  ↓
Ask user for surname to search (SearchContact)
  ↓
Use binary search to find (BinarySearchBySurname)
  ↓
Display result (found or not found)
  ↓
End
```

### Vets Surgery Flow:
```
Start
  ↓
Find CSV file (GetFileName)
  ↓
Create 2D array [10,2]
  ↓
Load appointments into array (LoadAppointments)
  ↓
Display all appointments (DisplayAppointments)
  ↓
Search for first available slot (FindFirstAvailableSlot)
  ↓
Use linear search (LinearSearchFirstAvailable)
  ↓
Display result (time or all booked)
  ↓
End
```

## Next Steps After Running

1. **Read the code** while looking at the output
2. **Trace through** with example data on paper
3. **Modify** the CSV files and re-run
4. **Add features** (see README-CHALLENGES.md for ideas)
5. **Compare** binary search vs linear search speeds

## Performance Comparison

Try this experiment:

1. **Create large CSV files:**
   - Phone directory with 1000 contacts
   - Appointments with 1000 slots

2. **Time the searches:**
   - Binary search (Phone Directory) → Very fast!
   - Linear search (Vets Surgery) → Slower

3. **Observe:**
   - Binary search speed doesn't change much with more data
   - Linear search gets noticeably slower with more data

This demonstrates why algorithm choice matters!

## Questions to Answer While Testing

1. What happens if you search for a surname with wrong capitalization?
2. What happens if the CSV file is empty?
3. What happens if all appointment slots are booked?
4. Does the phone directory work if contacts aren't sorted in the CSV?
5. What happens if you have duplicate surnames?

Try to answer these by running the programs!

## Need Help?

1. Read the overview files:
   - PhoneDirectory-OVERVIEW.md
   - VetsSurgery-OVERVIEW.md

2. Check the main README:
   - README-CHALLENGES.md

3. Look at code comments (the lines starting with //)

4. Trace through the code step by step

## Success Checklist

- [ ] Phone Directory compiles without errors
- [ ] Phone Directory finds existing contacts correctly
- [ ] Phone Directory shows "not found" for missing contacts
- [ ] Phone Directory search is case-insensitive
- [ ] Vets Surgery compiles without errors
- [ ] Vets Surgery displays all 10 appointment slots
- [ ] Vets Surgery finds first available slot correctly
- [ ] Vets Surgery shows "all booked" when appropriate
- [ ] You understand how binary search works
- [ ] You understand how linear search works
- [ ] You understand the difference between List and 2D array

If you've checked all these boxes, congratulations! You've successfully completed both challenges! 🎉
