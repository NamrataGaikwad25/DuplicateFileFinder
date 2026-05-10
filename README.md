# Duplicate File Finder Tool

## Overview

The Duplicate File Finder Tool is a console-based application developed in C# using .NET. The application scans a directory tree recursively and identifies duplicate source files across multiple project folders.

This project was developed as part of the Tieto Apprenticeship Assessment to demonstrate problem-solving skills, object-oriented design, file handling, hashing techniques, and clean code structure.

The tool supports two duplicate detection modes:

1. Basic Mode

   * Detects duplicates using file names only.

2. Extended Mode

   * Detects duplicates using both file names and file contents using SHA-256 hashing.

---

# Features

* Recursive directory scanning
* Supports:

  * `.c`
  * `.cpp`
  * `.h`
  * `.rc`
* Basic duplicate detection
* Extended duplicate detection using SHA-256 hashing
* Object-oriented project structure
* Duplicate grouping by project paths
* File size display
* Execution time measurement
* Output report generation (`output.txt`)
* Console-based interaction
* Exception handling

---

# Technologies Used

* C#
* .NET
* Object-Oriented Programming (OOP)
* SHA-256 Hashing
* LINQ
* File System APIs

---

# Project Structure

```text
DuplicateFileFinder
│
├── Models
│     └── FileRecord.cs
│
├── Utils
│     ├── FileHasher.cs
│     └── OutputWriter.cs
│
├── Program.cs
├── FileScanner.cs
├── DuplicateFinder.cs
└── README.txt
```

---

# File Descriptions

## Program.cs

The main entry point of the application.
Handles:

* User input
* Mode selection
* Application flow
* Execution timing
* Exception handling

---

## FileScanner.cs

Responsible for:

* Recursive folder scanning
* Filtering supported file types
* Collecting file information

Uses:

```csharp
SearchOption.AllDirectories
```

to scan nested folders recursively.

---

## DuplicateFinder.cs

Contains duplicate detection logic.

### Basic Mode

Compares:

* File name only

### Extended Mode

Compares:

* File name
* SHA-256 file hash

Uses LINQ grouping for efficient duplicate identification.

---

## FileHasher.cs

Generates SHA-256 hashes for file content comparison.

This ensures accurate duplicate detection in Extended Mode.

---

## OutputWriter.cs

Responsible for:

* Displaying duplicate groups
* Showing project paths
* Displaying file sizes
* Saving output to `output.txt`

---

## FileRecord.cs

Model class used to store:

* File name
* Full path
* Project path
* File hash
* File size

---

# How the Application Works

1. User enters the folder path.
2. Application recursively scans all folders and subfolders.
3. Supported source files are collected.
4. User selects:

   * Basic Mode
   * Extended Mode
5. DuplicateFinder groups duplicate files.
6. Output is displayed in the console.
7. Results are saved to `output.txt`.

---

# Supported File Extensions

| Extension | Description     |
| --------- | --------------- |
| .c        | C Source File   |
| .cpp      | C++ Source File |
| .h        | Header File     |
| .rc       | Resource File   |

---

# Example Folder Structure

```text
D:\TestFolder
│
├── A
│     ├── X.cpp
│     ├── Y.h
│     └── Z.c
│
├── B
│     ├── X.cpp
│     ├── Y.h
│     └── Z.c
│
└── C
      └── Z.c
```

---

# Example Output

```text
D:\TestFolder\A
D:\TestFolder\B
    X.cpp

D:\TestFolder\A
D:\TestFolder\B
    Y.h

D:\TestFolder\A
D:\TestFolder\B
D:\TestFolder\C
    Z.c
```

---

# Results

## Test Case 1 — Basic Mode

In Basic Mode, duplicate files are identified using only file names. The application scanned 7 supported source files and detected 3 duplicate groups: `X.cpp`, `Y.h`, and `Z.c`. Even if file contents are different, files with the same names are treated as duplicates in this mode.

<img width="940" height="1065" alt="image" src="https://github.com/user-attachments/assets/e0fafbcb-dcd7-4c47-9c60-4138fbecc888" />

---

## Test Case 2 — Extended Mode (Same Content)

In Extended Mode, duplicate files are identified using both file names and file content through SHA-256 hash comparison. The application detected 3 duplicate groups because all duplicate files had identical content across the project folders.

<img width="940" height="1019" alt="image" src="https://github.com/user-attachments/assets/0c793104-da6f-438e-8902-89529ffd4581" />

---

## Test Case 3 — Extended Mode (Different Content)

In this test case, the file `X.cpp` had the same name but different content in different folders. Therefore, the application detected only 2 duplicate groups: `Y.h` and `Z.c`. This confirms that Extended Mode correctly validates both file name and file content before marking files as duplicates.

<img width="826" height="1029" alt="image" src="https://github.com/user-attachments/assets/3e7429c7-c4fe-4ce3-aa02-9486144fa9ad" />



# Performance Considerations

* Recursive scanning supports deep folder structures.
* SHA-256 hashing improves accuracy of duplicate detection.
* LINQ grouping improves readability and maintainability.
* Designed to support large directory trees and multiple projects.


# How to Run

## Using Visual Studio

1. Open solution in Visual Studio.
2. Build the project.
3. Run the application.

---

# User Inputs

## Folder Path

Example:

```text
D:\TestFolder
```

## Mode Selection

```text
1 = Basic (File name only)
2 = Extended (File name + content)
```

---

# Sample Execution

```text
Enter folder path:
D:\TestFolder

Scanning files...

Files scanned: 7

Select Mode:
1 = Basic (File name only)
2 = Extended (File name + content)

Duplicate groups: 3
```

---

# Output File

The duplicate analysis report is automatically stored in:

```text
Desktop/output.txt
```

---

# Object-Oriented Design

The project follows object-oriented principles by separating:

* File scanning
* Duplicate detection
* Hash generation
* Output generation
* Data modeling

into independent classes for better readability and maintainability.

---

# Author

Developed by Namrata Gaikwad as part of the Tieto Apprenticeship Assessment using C# and .NET.
