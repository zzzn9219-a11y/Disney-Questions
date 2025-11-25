# Disney Quiz Program - Simple Overview

## 🎯 What Does This Program Do?
This program creates a fun Disney quiz! It reads Disney questions from an Excel file, picks 5 random questions, asks them to you, checks your answers, and tells you your score at the end.

---

## 📦 What's Inside the Code?

### 1️⃣ **Question Record** (Line 10)
Think of this as a "container" that holds two pieces of information together:
- The question (like "Who is the main character in Frozen?")
- The answer (like "elsa")

```csharp
public record Question(string QuestionText, string Answer);
```

**Simple Example:**
```csharp
Question q1 = new Question("What is 2+2?", "4");
// q1.QuestionText = "What is 2+2?"
// q1.Answer = "4"
```

---

### 2️⃣ **Main Method** (Where Everything Starts)
This is like the "start button" of your program. It runs three steps:

**Step 1:** Find the Excel file  
**Step 2:** Read all questions from the file  
**Step 3:** Start the quiz

```csharp
static void Main(string[] args)
{
    string fileName = GetFileName();           // Step 1
    List<Question> questions = LoadQuestions(fileName); // Step 2
    RunQuiz(questions);                        // Step 3
}
```

---

### 3️⃣ **GetFileName() Method**
**What it does:** Finds your DisneyQuestions.xlsx file

**How it works:**
1. **First check:** Looks in the current directory (where the program is running)
2. **Second check:** Looks in the project directory (where your code files are)
   - This is helpful in Visual Studio because it runs from `bin/Debug/net6.0`
   - The method automatically goes up 3 folders to find your project root
3. **Last resort:** If still not found, asks you: "Where is the file?"
   - You type the full path and press Enter

**Returns:** The location of the file (as text)

**Smart Path Detection:**
```csharp
// Uses AppContext.BaseDirectory (where the .exe is running from)
// Goes up 3 levels: bin/Debug/net6.0 → bin/Debug → bin → project root
string projectPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", fileName);
```

---

### 4️⃣ **LoadQuestions() Method**
**What it does:** Opens the Excel file and reads ALL the questions into a list

**How it works:**
1. Opens the Excel file
2. Goes through each row (one row = one question)
3. Takes Column A (the question) and Column B (the answer)
4. Puts them together in a Question record
5. Adds the Question to a list

**Returns:** A list containing all questions from the file

**Think of it like this:**
```
Excel File:              →  List in Memory:
Row 1: Q1 | Answer1      →  [Question1, Question2, Question3, ...]
Row 2: Q2 | Answer2      →
Row 3: Q3 | Answer3      →
```

---

### 5️⃣ **RunQuiz() Method** (The Main Game!)
**What it does:** Runs the actual quiz - asks 5 questions, checks answers, keeps score

**How it works:**

**Setup:**
- Creates a copy of all questions (so we can remove them as we use them)
- Sets score to 0
- Gets ready to pick random questions

**The Quiz Loop (repeats 5 times):**
1. **Pick a random question** from the available questions
2. **Show the question** on screen
3. **Get your answer** (you type and press Enter)
4. **Check if you're right:**
   - If correct → Say "Correct!" and add 1 to score
   - If wrong → Show the right answer
5. **Remove that question** from the list (so it can't be picked again)

**After 5 questions:**
- Shows your final score
- Gives you a message based on how well you did

---

## 🔑 Important Concepts Explained Simply

### What is a "List"?
A list is like a shopping list, but for your program. You can:
- Add items to it
- Remove items from it
- Count how many items are in it
- Pick an item by its position

```csharp
List<Question> myQuestions = new List<Question>();
myQuestions.Add(question1);  // Add a question
myQuestions.Remove(question1); // Remove it
int count = myQuestions.Count; // How many questions?
```

### How Do We Pick Random Questions?
We use the `Random` class (like rolling dice):

```csharp
Random random = new Random();
int randomNumber = random.Next(5); // Picks a number from 0 to 4
```

In our quiz:
- If we have 15 questions, `random.Next(15)` picks a random number between 0 and 14
- We use that number to pick a question from our list

### Why Do We Remove Questions After Using Them?
So the same question doesn't appear twice! 

**Example:**
- Start with 15 questions
- Pick question #7 → Remove it → Now we have 14 questions
- Pick question #3 → Remove it → Now we have 13 questions
- Question #7 can never be picked again!

---

## 📊 How The Program Flows

```
START
  ↓
Find Excel File (GetFileName)
  ├─ Check current directory
  ├─ Check project directory (Visual Studio compatibility)
  └─ Ask user if not found
  ↓
Read All Questions from Excel (LoadQuestions)
  ↓
Make a copy of questions
  ↓
Loop 5 times:
  ├─ Pick random question
  ├─ Show question
  ├─ Get user's answer
  ├─ Check if correct
  ├─ Update score
  └─ Remove that question
  ↓
Show final score
  ↓
END
```

---

## 🎮 Example of What Happens

**Excel File has:**
```
Row 1: "Who is Mickey's girlfriend?" | "minnie"
Row 2: "What is Simba's dad's name?" | "mufasa"
Row 3: "Where does Aladdin live?" | "agrabah"
... (12 more questions)
```

**Program runs:**

1. Reads all 15 questions into a list
2. Copies the list (so we have 15 questions to pick from)
3. Randomly picks question #8: "Who is Mickey's girlfriend?"
4. You type: "Minnie"
5. Program checks: "minnie" == "minnie" ✅ Correct! Score = 1
6. Removes question #8 from available questions (14 left)
7. Repeats 4 more times...
8. Shows: "Final Score: 4 out of 5"

---

## 💡 Key Programming Concepts Used

### Records (Simple Data Storage)
```csharp
// Instead of creating a whole class, we use a record for simple data
public record Question(string QuestionText, string Answer);
```

### Methods/Subroutines (Breaking code into pieces)
Instead of writing everything in Main, we break it into smaller pieces:
- `GetFileName()` - Just handles finding the file
- `LoadQuestions()` - Just handles reading questions
- `RunQuiz()` - Just handles running the quiz

This makes code easier to understand and fix!

### Case-Insensitive Comparison
```csharp
userAnswer.ToLower() == correctAnswer.ToLower()
```
This means "MICKEY", "mickey", and "MiCkEy" are all treated as the same answer.

---

**Great job! 🎉**