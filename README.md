# FakeUpdate
The app which creates a Windows Update experience

NOTE: As this app is written in C#, .NET Framework 4.6.1 is required.

## New features in Update Simulator version 2.0.0.0

### Command line arguments:
--i (previously --p): Text for indicator

--br (New): Amount of red of the background

--bg (New): Amount of green of the background

--bb (New): Amount of blue of the background

--fr (New): Amount of red of the foreground

--fg (New): Amount of green of the background

--bg (New): Amount of blue of the background

--d (New): Time (in seconds) you need to wait before the progress change (valid range: 1 - 10)

--enable-unsafe (New): Launch GUI in Unsafe mode and ignores other flags

### New GUI

Now, Update Simulator has a brand new GUI that can control all parts of the Update, just like the command arguments.

Click "Update" for the Update screen.

## Windows 7 Experience

IMPORTANT: The Windows 7 Experience is ignored when you setup the Update screen in CMD.

Update Simulator now brings you the Windows 7 Update Experience.

Previously, I couldn't find the loading icon of Windows 7. But now, I have found it, properly fixed the code and it works.


## Command-line arguments
For all command line helps, type --help or --h. For example: FakeUpdate.exe --help

NOTE: To exit the app after --help or --h argument, you need to press Enter.

If you're too lazy to type it yourselves, here you come:

--t: Change the title (default: Configuring critical Windows Updates)

--i (previously --p): Text for indicator

--br (New): Amount of red of the background

--bg (New): Amount of green of the background

--bb (New): Amount of blue of the background

--fr (New): Amount of red of the foreground

--fg (New): Amount of green of the background

--bg (New): Amount of blue of the background

--d (New): Time (in seconds) you need to wait before the progress change (valid range: 1 - 10)

--enable-unsafe (New): Launch GUI in Unsafe mode and ignores another flags

--r: Change the request when the computer is "updating" (default: Do not turn off your PC)

--c: The command to run when 100% reached

--h: Show help

NOTE:
  - To use spaces in your text, wrap your text in quotes `"like this"`
  - Using a CMD can be dangerous, by using the wrong CMD command you can potentially destroy your PC! Please always check what you are intended to run.
  - Using --h, -help or --enable-unsafe will ignore all other arguments, so if you want to change the design in CMD, please make sure --h, --help or --enable-unsafe is not available

## Trademarks
Thanks to:
  - FlyTech Videos (for some ideas and design)
  - fakeupdate.net (for some ideas and design)
