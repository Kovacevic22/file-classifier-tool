# File Classifier

CLI tool for scanning and organizing files into categories (Images, Documents, Executables) based on file extension.

## Download

| OS | Download |
|----|----------|
| Windows | [file-classifier-win-x64.zip](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.1/file-classifier-win-x64.zip) |
| Linux | [file-classifier-linux-x64.zip](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.1/file-classifier-linux-x64.zip) |
| macOS | [file-classifier-osx-x64.zip](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.1/file-classifier-osx-x64.zip) |

## Usage

```bash
# Organize current folder into destination
file-classifier [destination]

# Organize specific folder into destination
file-classifier [destination] [source]
```

### Examples

```bash
# Windows
FileClassifier.CLI.exe file-classifier C:\Organized C:\Downloads

# Linux/macOS
./FileClassifier.CLI file-classifier /home/user/Organized /home/user/Downloads
```

## Categories

Files are organized into folders based on extension:

| Category | Extensions |
|----------|-----------|
| Image | .jpg, .jpeg, .png, .gif |
| Document | .doc, .docx, .pdf, .ppt, .pptx |
| Executable | .exe, .bat |
| Unknown | everything else |

## Running via .NET (developer)

#1
```bash
# Clone the repository
git clone https://github.com/Kovacevic22/file-classifier-tool.git
```
#2
```bash
# Build the project from the root directory
dotnet build
```
#3
```bash
# Navigate to the FileClassifier.CLI project directory
cd FileClassifier.CLI

# Run the application using following command
dotnet run -- file-classifier [destination] [source]
```

### Arguments Configuration

*   `[destination]` (Output): The path to an existing folder where the tool will create the category subfolders (`Images`, `Documents`, `Executables`, `Unknown`) and move the sorted files.
*   `[source]` (Input - Optional): The path to the folder containing the unorganized files you want to scan. If you don't provide a source path, the default path is the folder you are currently in.

#### Examples

#1. Organizing a specific source folder:
```bash
dotnet run -- file-classifier "C:\MyTargetFolder" "C:\Users\Name\Downloads"
```

#2. Organizing the current folder:
```bash
dotnet run -- file-classifier "C:\MyTargetFolder"
```

