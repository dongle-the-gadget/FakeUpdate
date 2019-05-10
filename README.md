# FakeUpdate
The app which creates a Windows Updates experience

NOTE: As this app is written in C#, .NET Framework 4.6.1 is required.
## Command-line arguments
For all command line helps, type --help or --h. For example: FakeUpdate.exe --help

NOTE: To exit the app after --help or --h argument, you need to press Enter.

But I'm going to tell you:

--t: Change the title (default: Configuring critical Windows Updates)

--p: Change the text "complete" to anything you like (default: complete) (example: you type --p fuck!, instead of 0% complete, you will get 0% fuck!)

--r: Change the request when the computer is "updating" (default: Do not turn off your PC)

--c: The command to run when 100% reached

--h: Show help

NOTE:
  - To use spaces in your text, wrap your text in quotes "like this"
  - Using a CMD can be dangerous, by using the wrong CMD command you can potentially destroy your PC! Please always check what you are intended to run.
  - Using --h or --help will ignore all other arguments, so if you use --t, --p, --r, --c please make sure --h or --help is not available
## Copyright

As this app is open-source, you are allowed to edit this app and publish that changes, make sure that:

1. Your changes does not support for malicious intent (like inserting malware in the app).

2. You are not allowed to make a profit (this app is free for everyone).

3. Add this link to your website (if you publish it).

## Trademarks
Thanks to:
  - FlyTech Videos (for some ideas and design)
  - fakeupdate.net (for some ideas and design)
