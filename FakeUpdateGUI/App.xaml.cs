using FakeUpdate.Models;
using FakeUpdate.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace FakeUpdate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int AttachParentProcess = -1;

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                UpdateBase bluescreenData = new Windows10Update();
                var showHelp = false;
                var enableUnsafe = false;

                var p = new OptionSet
                {
                    { "t|title=", "{Text} for title",  t => bluescreenData.Title = t},
                    { "r|request=", "{Text} for request for the user to obey when updating", t => bluescreenData.UpdatingRequest = t },
                    { "i|indicator=", "{Text} for progress indicator", t => bluescreenData.Indicator = t },
                    { "br|backred=", "{Amount} of red of background", t => bluescreenData.BackgroundColor.R =
                        byte.Parse(t)},
                    { "bg|backgreen=", "{Amount} of green of background", t => bluescreenData.BackgroundColor.G =
                        byte.Parse(t)},
                    { "bb|backblue=", "{Amount} of blue of background", t => bluescreenData.BackgroundColor.B =
                        byte.Parse(t)},
                    { "fr|forered=", "{Amount} of red of foreground", t => bluescreenData.ForegroundColor.R =
                        byte.Parse(t)},
                    { "fg|foregreen=", "{Amount} of green of foreground", t => bluescreenData.ForegroundColor.G =
                        byte.Parse(t)},
                    { "fb|foreblue=", "{Amount} of blue of foreground", t => bluescreenData.ForegroundColor.B =
                        byte.Parse(t)},
                    { "d|delay=", "{Duration} during update (1-10) seconds", (int d) =>
                    {
                        if(d < 1 || d > 10)
                        {
                            throw new OptionException("Duration limit is from 1 seconds to 10 seconds", "d|delay=");
                        }
                        else
                        {
                            bluescreenData.Seconds = d;
                        }
                    } },
                    { "c|cmd=", "The {command} to run after complete (Be careful!)", c => { bluescreenData.Command = c; } },
                    { "u|enable-unsafe", "Enter Unsafe mode (forces GUI mode and discards all other settings)", h => enableUnsafe = h != null },
                    { "h|help", "Show this message and exit", h => showHelp = h != null }
                };

                List<string> extra;
                try
                {
                    extra = p.Parse(args);
                }
                catch (Exception ex)
                {
                    if (AttachConsole(AttachParentProcess))
                    {
                        Console.WriteLine("\n");
                        Console.Write("FakeUpdate: ");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Try `--help' for more information.");
                        Console.WriteLine();
                        FreeConsole();
                    }
                    Shutdown(1);
                    return;
                }
                if (showHelp)
                {
                    ShowHelp(p);
                    return;
                }

                if (enableUnsafe)
                {
                    MessageBox.Show("You are entering Unsafe Mode. Be careful!", "Careful", MessageBoxButton.OK, MessageBoxImage.Warning);
                    RunGui(true);
                }
                else
                {
                    bluescreenData.ShowView();
                }
            }
            else
            {
                RunGui(false);
            }
        }

        private void RunGui(bool v)
        {
            MainWindow mainWindow = new MainWindow(v);
            mainWindow.Show();
        }

        private void ShowHelp(OptionSet p)
        {
            if (AttachConsole(AttachParentProcess))
            {
                Console.WriteLine("\n");
                Console.WriteLine("FakeUpdate Options:");
                p.WriteOptionDescriptions(Console.Out);
                Console.WriteLine();
                Console.WriteLine("IMPORTANT:");
                Console.WriteLine(" - If you are using Windows 7, background color is ignored.");
                Console.WriteLine(" - To use spaces in your text, wrap your text in quotes \"like this\".");
                Console.WriteLine(" - Unsafe mode and help will ignore all other flags.");
                Console.WriteLine(" - Using a CMD command can be dangerous. If you use the --c flag, please consider reading the command again to prevent damages.");
                Console.WriteLine();
                FreeConsole();
            }
            Shutdown();
        }
    }
}
