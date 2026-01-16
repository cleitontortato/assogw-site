Act as a DevOps Engineer. I need to initialize the git repository for this ASP.NET Core project.

1.  **Generate a `.gitignore` file**:
    -   It must follow the standard Visual Studio and .NET Core exclusion rules.
    -   Ignore build folders (`bin/`, `obj/`).
    -   Ignore IDE specific folders (`.vs/`, `.vscode/`, `.idea/`).
    -   Ignore user-specific files (`*.user`, `*.suo`).
    -   Ignore sensitive environment files (`appsettings.Development.json` usually, but for this demo, ensure `appsettings.Local.json` is ignored).
    -   Ignore OS system files (`.DS_Store`, `Thumbs.db`).

2.  **Git Initialization Script**:
    -   Provide the sequence of bash commands to:
        -   Initialize the repo.
        -   Add the files.
        -   Make the first commit with the message "Initial structure: Home, News, Dealerships and Contact".

Output the `.gitignore` content in a code block and the shell commands in another.