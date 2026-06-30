# File Classifier

CLI tool for scanning and organizing files into categories (Images, Documents, Executables) based on file extension.

## Download

| OS | Download |
|----|----------|
| Windows | [file-classifier-win-x64.zip](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.0/file-classifier-win-x64.zip) |
| Linux | [file-classifier-linux-x64.zip](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.0/file-classifier-linux-x64.zip) |
| macOS | [file-classifier-osx-x64.zip](https://github.com/Kovacevic22/file-classifier-tool/releases/download/v1.0.0/file-classifier-osx-x64.zip) |

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
