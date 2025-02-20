import os
import sys

def print_tree(path, exclude_dirs=None, level=0, prefix=""):
    if exclude_dirs is None:
        exclude_dirs = {
            ".vs", "bin", "obj", "packages", ".vscode", ".idea", "__pycache__", ".git", ".github",
            "TestResults", "node_modules", "dist", "build", ".venv", "venv"
        }

    try:
        entries = os.listdir(path)
    except PermissionError:
        return

    # Filter out files, and directories in the exclude list
    entries = [entry for entry in sorted(entries) if os.path.isdir(os.path.join(path, entry)) and entry not in exclude_dirs]

    # Process directories and subdirectories
    for i, entry in enumerate(entries):
        entry_path = os.path.join(path, entry)
        is_last = (i == len(entries) - 1)

        # Set the appropriate prefix for the lines and arrows (using Unicode)
        if is_last:
            connector = "└── "
            new_prefix = f"{prefix}    "
        else:
            connector = "├── "
            new_prefix = f"{prefix}│   "

        # Print the current directory with the correct tree structure
        print(f"{prefix}{connector}{entry}/")

        # Recursively call the function for subdirectories
        print_tree(entry_path, exclude_dirs, level + 1, new_prefix)

# Set UTF-8 encoding for standard output
sys.stdout.reconfigure(encoding='utf-8')

base_path = "."

with open("tree.txt", "w", encoding="utf-8") as file:
    sys.stdout = file
    print_tree(base_path)
