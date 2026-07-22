# File Classifier

CLI tool for scanning and organizing files into categories (Images, Documents, Executables) based on file extension.

## Download

| OS | Download |
|----|----------|
| Windows | [file-classifier-win-x64](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.0/FileClassifier.CLI.exe) |
| Linux | [file-classifier-linux-x64](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.0/FileClassifier.CLI) |

## Usage

The tool uses flexible flags, meaning **the order of arguments does not matter**.

### Available Options
* `-h`, `--help` - Show help menu.
* `-s`, `--scan` - Scan and print files from the directory.
* `-sr`, `--source <path>` - Specify the source directory (optional, defaults to the current directory).
* `-d`, `--destination <path>` - Specify the destination directory where files will be organized.

### Examples

```bash
# Show help menu
./FileClassifier.CLI --help

# Scan current folder
./FileClassifier.CLI --scan

# Scan a specific folder
./FileClassifier.CLI --scan --source /path/to/source

# Organize specific source into destination (Requires user confirmation)
./FileClassifier.CLI --destination /path/to/dest --source /path/to/source

# Organize current folder into destination (Order doesn't matter)
./FileClassifier.CLI -d /path/to/dest
```

## Categories

Files are organized into folders based on extension:

| Category | Extensions |
|----------|-----------|
| Image | .jpg, .jpeg, .png, .gif |
| Document | .doc, .docx, .pdf, .ppt, .pptx |
| Executable | .exe, .bat |
| Unknown | everything else |

## Getting Started (Development)

Follow these steps to set up, build, and run the project locally on your machine.

### Prerequisites
* [.NET 8.0 SDK](https://microsoft.com) (or newer)

### 1. Clone the Repository
```bash
git clone https://github.com/Kovacevic22/file-classifier-tool.git
cd file-classifier-tool
```

### 2. Build the Project
```bash
dotnet build
```

### 3. Run Locally
```bash
# Navigate to the CLI project
cd FileClassifier.CLI

# Run the help command
dotnet run -- --help

# Run scanning on a specific folder
dotnet run -- --scan --source /path/to/folder
```
*Note: The `--` separator is required to pass flags directly to the CLI application rather than the `dotnet` tooling itself.*

### 4. Publish (Create Executable)
To generate a single, self-contained executable file for your specific OS:
```bash
dotnet publish -c Release -r linux-x64 --self-contained
```
*(Replace `linux-x64` with `win-x64` for Windows or `osx-arm64` for Apple Silicon macOS).*

