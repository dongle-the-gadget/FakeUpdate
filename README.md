# FakeUpdate
The app which creates a Windows Updates experience

NOTE: As this app is written in C#, .NET Framework 4.6.1 is required.

## New features in Update Simulator version 2.0.0.0

### Command line arguments:
--i (replaced from --p): Text for indicator

--br (New): Amount of red of the background

--bg (New): Amount of green of the background

--bb (New): Amount of blue of the background

--fr (New): Amount of red of the foreground

--fg (New): Amount of green of the background

--bg (New): Amount of blue of the background

--d (New): Time (in seconds) you need to wait before the progress change (valid range: 1 - 10)

--enable-unsafe (New): Launch GUI in Unsafe mode and ignores another flags

### Newly-design GUI

Now, Update Simulator has a brand new GUI that can control all parts of the Update, just like the command arguments.

Click "Update" for the Update screen.

## Windows 7 Experience

IMPORTANT: 

1. The Windows 7 Experience is ignored when you setup the Update screen in CMD.

2. The ProgressRing has not been updated yet, I'm still using the Windows 10 ProgressRing.

Update Simulator now brings you the Windows 7 Update Experience.


## Command-line arguments
For all command line helps, type --help or --h. For example: FakeUpdate.exe --help

NOTE: To exit the app after --help or --h argument, you need to press Enter.

But I'm going to tell you:

--t: Change the title (default: Configuring critical Windows Updates)

--i (replaced from --p): Text for indicator

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
  - To use spaces in your text, wrap your text in quotes "like this"
  - Using a CMD can be dangerous, by using the wrong CMD command you can potentially destroy your PC! Please always check what you are intended to run.
  - Using --h or --help will ignore all other arguments, so if you use --t, --p, --r, --c please make sure --h or --help is not available
## Copyright
This computer program is protected by copyright law and international treaties. Unauthorized reproduction or distribution of this program, or any portion of it, may result iin severe civil and criminal penalties, and will be prosecuted to the maximum extent under law.

❌ Commercial use

❌ Warranty

❌ Liability

✔ Non-commercial use

## Trademarks
Thanks to:
  - FlyTech Videos (for some ideas and design)
  - fakeupdate.net (for some ideas and design)
