# Vets Surgery - Simple Overview

## What Does This Program Do?

This program manages appointments for a veterinary surgery (animal doctor). It shows which appointment times are available and which are already booked.

## How It Works - Step by Step

### 1. **Starting the Program**
   - The program displays a title
   - It looks for a file called `appointments.csv`

### 2. **Loading Appointments**
   - Opens the CSV file with booking information
   - Reads each line which has: Time, Customer ID
   - Example: `09:00:00,5877RC` (booked) or `10:00:00,` (available)
   - Stores all appointments in a **2D array** (like a table with rows and columns)

### 3. **Displaying All Appointments**
   - Shows a table with 10 appointment slots
   - Each row shows: Slot number, Time, Customer ID, Status (Available/Booked)

### 4. **Finding First Available Slot**
   - Uses **linear search** to find the first empty slot
   - Shows the time if an appointment is available
   - Shows "all booked" message if no slots are free

## Important Parts Explained

### What is a 2D Array?
```csharp
string[,] appointments = new string[10, 2];
```
- A **2D array** is like a table or spreadsheet
- It has **rows** (going down) and **columns** (going across)
- `[10, 2]` means:
  - 10 rows (for 10 appointment slots)
  - 2 columns (for time and customer ID)

**Visual representation:**
```
Row | Column 0 (Time) | Column 1 (Customer ID)
----|-----------------|----------------------
 0  | 09:00:00        | 5877RC
 1  | 09:30:00        | 9655AS
 2  | 10:00:00        | (empty - available!)
 3  | 10:30:00        | 8754TT
 4  | 11:00:00        | (empty - available!)
```

### Accessing 2D Array Elements
```csharp
appointments[0, 0] = "09:00:00"     // Row 0, Column 0 (first time)
appointments[0, 1] = "5877RC"       // Row 0, Column 1 (first customer ID)
appointments[2, 1] = ""             // Row 2, Column 1 (empty = available)
```
- `appointments[row, column]` accesses one cell in the table
- Row numbers start at 0
- Column numbers start at 0

### What is Linear Search?
Linear search is a **simple way to find something** by checking each item one by one:

1. Start at the **first** item
2. Check: Is this what I'm looking for?
   - **Yes?** → Found it! Stop searching ✓
   - **No?** → Move to the next item
3. Repeat until you find it (or reach the end)

**Example:**
Finding first available slot in: Booked, Booked, Available, Booked, Available, ...

```
Step 1: Check slot 1 (09:00) → Booked → Keep searching
Step 2: Check slot 2 (09:30) → Booked → Keep searching
Step 3: Check slot 3 (10:00) → Available → Found it! ✓
        Return slot 3
```

**Why use linear search here instead of binary search?**
- We want the **first** available appointment
- We need to check in time order (earliest to latest)
- Linear search checks from beginning to end, which is perfect for this!

### How File Reading Works
```csharp
string[] lines = File.ReadAllLines(fileName);
```
- Opens the CSV file
- Reads all lines at once
- Each line becomes one item in an array

```csharp
string[] parts = line.Split(',');
```
- Takes one line: `09:00:00,5877RC`
- Splits it at the comma
- Creates array: `["09:00:00", "5877RC"]`
- `parts[0]` = "09:00:00" (time)
- `parts[1]` = "5877RC" (customer ID)

For an available slot: `10:00:00,`
- Splits into: `["10:00:00", ""]`
- `parts[0]` = "10:00:00" (time)
- `parts[1]` = "" (empty - no customer)

### Checking if a Slot is Available
```csharp
if (string.IsNullOrWhiteSpace(customerId))
{
    // This slot is available!
}
```
- `IsNullOrWhiteSpace()` checks if text is empty or just spaces
- Returns `true` if the customer ID is blank
- Returns `false` if there's a customer ID (slot is booked)

### Getting Array Dimensions
```csharp
appointments.GetLength(0)  // Gets number of rows (10)
appointments.GetLength(1)  // Gets number of columns (2)
```
- `GetLength(0)` tells us how many rows
- `GetLength(1)` tells us how many columns

## The Subroutines (Functions)

### 1. `GetFileName()`
**What it does:** Finds the appointments.csv file
- First looks in the current folder
- Then looks in the project folder
- If not found, asks you to type the location

### 2. `LoadAppointments(fileName, appointments)`
**What it does:** Reads all appointments from the file
- Opens the CSV file
- Reads each line
- Splits each line into time and customer ID
- Stores in the 2D array:
  - Column 0: Time
  - Column 1: Customer ID (blank if available)

### 3. `DisplayAppointments(appointments)`
**What it does:** Shows all appointment slots in a table
- Creates a formatted table
- Shows each slot with:
  - Slot number (1-10)
  - Time
  - Customer ID (or blank)
  - Status (Available or Booked)

### 4. `FindFirstAvailableSlot(appointments)`
**What it does:** Finds the first free appointment
- Calls the linear search function
- Displays the time if available
- Shows "all booked" message if nothing available

### 5. `LinearSearchFirstAvailable(appointments)`
**What it does:** Searches for first empty slot
- Starts at row 0 (first appointment)
- Checks each row one by one
- Looks at column 1 (customer ID)
- If it's blank → returns that row number
- If all slots are booked → returns -1

## Example Run

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

## Key Learning Points

1. **2D Arrays** store data in rows and columns (like a table)
2. **CSV files** can have empty values (shown by nothing between commas)
3. **Linear search** checks each item one by one from start to finish
4. **Arrays** need two numbers to access data: `[row, column]`
5. **String checking** helps us determine if a slot is empty or has data
6. **Subroutines** can receive arrays as parameters and work with them
7. **GetLength()** tells us the size of each dimension in an array

## Linear Search vs Binary Search - When to Use Which?

### Use **Linear Search** when:
- You want the **first** item that matches (like first available appointment)
- Data doesn't need to be sorted
- You're searching through a small amount of data
- Order matters (checking from beginning to end)

### Use **Binary Search** when:
- You want to find **any** matching item (not necessarily the first)
- Data is sorted (or you can sort it first)
- You're searching through lots of data (much faster!)
- Order doesn't matter as long as you find the item

## Understanding 2D Arrays Step by Step

**Creating a 2D array:**
```csharp
string[,] appointments = new string[10, 2];
```
This creates a table like this (all empty at first):

```
       Column 0    Column 1
Row 0:  [empty]     [empty]
Row 1:  [empty]     [empty]
Row 2:  [empty]     [empty]
...
Row 9:  [empty]     [empty]
```

**Filling the array:**
```csharp
appointments[0, 0] = "09:00:00";
appointments[0, 1] = "5877RC";
```

Now it looks like:
```
       Column 0      Column 1
Row 0:  09:00:00     5877RC
Row 1:  [empty]      [empty]
...
```

**Reading from the array:**
```csharp
string time = appointments[0, 0];        // Gets "09:00:00"
string customer = appointments[0, 1];    // Gets "5877RC"
```

## How the Linear Search Works - Detailed Example

Let's trace through finding the first available slot:

```csharp
static int LinearSearchFirstAvailable(string[,] appointments)
{
    for (int i = 0; i < appointments.GetLength(0); i++)
    {
        string customerId = appointments[i, 1] ?? "";

        if (string.IsNullOrWhiteSpace(customerId))
        {
            return i;  // Found first available!
        }
    }
    return -1;  // All booked
}
```

**Step-by-step execution:**

```
i = 0: Check row 0, column 1 → "5877RC" → Not empty → Continue
i = 1: Check row 1, column 1 → "9655AS" → Not empty → Continue
i = 2: Check row 2, column 1 → ""       → Empty! → Return 2 ✓
```

The function returns 2, meaning slot 3 (row 2, but we display as slot 3 because we add 1) is the first available appointment.

## Why This Matters for Real Life

Appointment systems like this are used everywhere:
- Doctors and dentists
- Hair salons
- Car repair shops
- Restaurant reservations
- Meeting room bookings

Understanding how to store and search appointment data is a practical programming skill!
