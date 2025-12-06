# How to Switch Between Programs in Visual Studio

## The Problem

You have **three different programs** in one project:
1. **Program.cs** - Disney Quiz (original)
2. **PhoneDirectory.cs** - Phone Directory with Binary Search
3. **VetsSurgery.cs** - Vets Surgery with Linear Search

Each has its own `Main()` method, which caused the error:
> "Program has more than one entry point defined"

## The Solution

The project file (`challenge5.csproj`) now specifies which program to run using the `<StartupObject>` tag.

---

## 🔄 How to Switch Programs

### Method 1: Edit the .csproj File (Recommended)

Open `challenge5.csproj` and find this line:
```xml
<StartupObject>VetsSurgeryApp.VetsSurgery</StartupObject>
```

**Change it to one of these:**

#### To run Disney Quiz:
```xml
<StartupObject>DisneyQuiz.Program</StartupObject>
```

#### To run Phone Directory:
```xml
<StartupObject>PhoneDirectoryApp.PhoneDirectory</StartupObject>
```

#### To run Vets Surgery:
```xml
<StartupObject>VetsSurgeryApp.VetsSurgery</StartupObject>
```

Then **save the file** and **rebuild** the project (Build → Rebuild Solution).

---

### Method 2: Visual Studio UI

1. **Right-click** on the project in Solution Explorer
2. Select **Properties**
3. Go to **Application** tab
4. Under **Startup object**, select from dropdown:
   - `DisneyQuiz.Program`
   - `PhoneDirectoryApp.PhoneDirectory`
   - `VetsSurgeryApp.VetsSurgery`
5. **Save** and **rebuild**

---

## 🎯 Current Configuration

**Currently set to run:** `VetsSurgeryApp.VetsSurgery` (Vets Surgery)

To switch to a different program:
1. Open `challenge5.csproj`
2. Change the `<StartupObject>` line
3. Save
4. Rebuild (Ctrl+Shift+B)
5. Run (F5)

---

## 📋 Quick Reference

| Program | Namespace | Class | StartupObject Value |
|---------|-----------|-------|---------------------|
| Disney Quiz | DisneyQuiz | Program | `DisneyQuiz.Program` |
| Phone Directory | PhoneDirectoryApp | PhoneDirectory | `PhoneDirectoryApp.PhoneDirectory` |
| Vets Surgery | VetsSurgeryApp | VetsSurgery | `VetsSurgeryApp.VetsSurgery` |

---

## 🔧 Troubleshooting

### Error: "Cannot find the entry point"
**Fix:** Make sure the `<StartupObject>` value matches exactly (case-sensitive):
- Namespace name + `.` + Class name
- Example: `VetsSurgeryApp.VetsSurgery`

### Error: "Multiple entry points defined"
**Fix:** Make sure the `<StartupObject>` line is present in the .csproj file.

### Changes not taking effect
**Fix:**
1. Save the .csproj file
2. Close and reopen Visual Studio
3. Or use: Build → Clean Solution, then Build → Rebuild Solution

### Still getting errors?
**Alternative solution:** Create separate projects for each program:
1. Create new Console App project
2. Copy one .cs file into it
3. Copy the corresponding .csv file
4. Run independently

---

## 🎓 Understanding the Fix

### Why This Happens
C# console applications need exactly **one** entry point - one `Main()` method that tells the program where to start.

When you have multiple `.cs` files with `Main()` methods in the same project, the compiler doesn't know which one to use.

### How `<StartupObject>` Works
This setting tells the compiler: **"Use THIS specific Main() method"**

Format: `<NamespaceName>.<ClassName>`

Example:
```csharp
namespace VetsSurgeryApp  // ← Namespace name
{
    class VetsSurgery     // ← Class name
    {
        static void Main(string[] args)  // ← Entry point
        {
            // ...
        }
    }
}
```

StartupObject would be: `VetsSurgeryApp.VetsSurgery`

---

## 💡 Pro Tip: Create Separate Projects

For easier switching, you could create three separate projects:

```
TeachingCSharp/
├── DisneyQuiz/
│   ├── DisneyQuiz.csproj
│   ├── Program.cs
│   └── DisneyQuestions.xlsx
│
├── PhoneDirectory/
│   ├── PhoneDirectory.csproj
│   ├── Program.cs  (contains PhoneDirectory code)
│   └── phonedirectory.csv
│
└── VetsSurgery/
    ├── VetsSurgery.csproj
    ├── Program.cs  (contains VetsSurgery code)
    └── appointments.csv
```

This way you can run each program independently without changing configuration!

---

## ✅ Verification Steps

After changing the startup object:

1. **Build the project** (Ctrl+Shift+B)
   - Should show "Build succeeded" with no errors

2. **Check Error List** (View → Error List)
   - Should show 0 errors
   - Warnings are okay (nullable reference warnings are normal)

3. **Run the program** (F5)
   - Should start the correct program
   - Should show the expected output

---

## 📝 Quick Commands in Visual Studio

- **Rebuild Project**: `Ctrl+Shift+B`
- **Run Program**: `F5`
- **Run Without Debugging**: `Ctrl+F5`
- **Stop Program**: `Shift+F5`
- **Show Error List**: `Ctrl+\, E`
- **Clean Solution**: Build Menu → Clean Solution

---

## Current Status

✅ Project configured to run **VetsSurgery**
✅ All three programs available in the project
✅ Easy to switch using `<StartupObject>` setting

**To run a different program:** Edit the `<StartupObject>` line in `challenge5.csproj` and rebuild!
