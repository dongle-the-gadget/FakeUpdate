# FakeUpdate
The app which creates a Windows Update experience.

.NET 5 Desktop Runtime or newer is required to run this program.

## New features in Update Simulator version 2.1

Program ported to .NET 5.0

## Command-line arguments
For all command line helps, type --help or --h. For example: FakeUpdate.exe --help

NOTE: To exit the app after --help or --h argument, you need to press Enter.

NOTE #2: If you use command line arguments, you will not get the Windows 7 update experience. Windows 10 only.

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
  - https://github.com/XamlAnimatedGif/WpfAnimatedGif (for Windows 7 progress ring animation)
  - MahApps (Windows 8/10 Progress Ring)
