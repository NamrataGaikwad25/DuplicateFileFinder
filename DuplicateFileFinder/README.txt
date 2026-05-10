Duplicate File Finder Tool
====================================

Description
-----------
This application scans a directory tree and identifies duplicate source files.

The program supports two modes:

1. Basic Mode
   - Detects duplicates using file name only.

2. Extended Mode
   - Detects duplicates using both file name and file content.
   - SHA-256 hashing is used for file content comparison.

Supported File Types
--------------------
- .c
- .cpp
- .h
- .rc

Features
--------
- Recursive directory scanning
- Duplicate file detection
- Basic and Extended comparison modes
- SHA-256 hash comparison
- Console output
- Output report generation to output.txt
- File size display
- Execution time measurement
- Object-oriented design

Project Structure
-----------------
- Program.cs
    Entry point of application

- FileScanner.cs
    Scans directories and collects files

- DuplicateFinder.cs
    Finds duplicate files

- FileHasher.cs
    Generates SHA-256 hash for file comparison

- OutputWriter.cs
    Displays and stores output

- FileRecord.cs
    Model class storing file information

Performance Considerations
--------------------------
- Recursive directory scanning is used to support deep folder structures.
- SHA-256 hashing allows efficient and accurate content comparison.
- The program is designed to handle thousands of files.

Future Improvements
-------------------
- Multithreading using Parallel.ForEach()
- GUI support
- Additional file type support
- Export to CSV or JSON

Limitations
-----------
- Binary files are not scanned.
- Large files may increase hashing time.
- Current implementation is single-threaded.

How to Run
----------
1. Build the project in Visual Studio.
2. Run the application.
3. Enter the folder path to scan.
4. Select:
    1 = Basic Mode
    2 = Extended Mode

Example
-------
Input Folder Structure:

/A
    X.cpp
    Y.h

/B
    X.cpp
    Y.h

/C
    Z.c

Output:

/A
/B
    X.cpp

/A
/B
    Y.h

Author
------
Developed in C# using .NET and Object-Oriented Programming principles.