# File Classifier

CLI tool for scanning and organizing files into categories (Images, Documents, Executables) based on file extension.

## Download

Go to [Releases](https://github.com/Kovacevic22/file-classifier-tool/releases) and download the binary for your OS:

- `file-classifier-win-x64.zip` - Windows
- `file-classifier-linux-x64.zip` - Linux
- `file-classifier-osx-x64.zip` - macOS

Extract the zip and run the binary directly - no installation required.

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
