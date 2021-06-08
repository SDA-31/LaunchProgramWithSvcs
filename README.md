# LaunchProgramWithSvcs

The program, as the name suggests, launches the desired application after activating the services specified in the arguments.

## How to use this ~sh*t~ program:
1. Create shortcut
2. Enter the properties of shortcut
3. In "Object" textbox, input the arguments.

## Arguments:
```
"Path to file" "Path to program" "Services to start (with spaces as separators)" "Arguments to program (with double quotes as separator)"
```

## Example:
```
"C:\Launch.Program.With.Services.exe" "C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe" "SQLWriter MySQL80" "--defaults-file=C:\ProgramData\MySQL\MySQL Server 8.0\my.ini" "-uroot" "-p"
```
