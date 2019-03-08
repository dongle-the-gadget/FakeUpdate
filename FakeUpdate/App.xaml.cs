using FakeUpdate.ViewModels;
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
                var updateData = new MainViewModel();
                bool showHelp = false;
                var p = new OptionSet
                {
                    { "t|title=", "{Text} for Title", t => updateData.Title = t },
                    { "p|progress=", "{Text} for 0% {complete}", t => updateData.Complete = t },
                    { "r|request=", "{Text} for request before completing the progress", t => updateData.RequestUpdating = t },
                    { "c|command=", "The {command} to run after complete (Be careful!)", t =>
                    {
                        if(!string.IsNullOrEmpty(t))
                        {
                            updateData.CompleteCommand = t;
                        }
                    }},
                    { "h|help", "Show this message and exit", h => showHelp = h != null}
                };
                List<string> extra;
                extra = p.Parse(args);

                if(showHelp)
                {
                    ShowHelp(p);
                    return;
                }
                else
                {
                    ShowGui(updateData);
                }
            }
            else
            {
                ShowGui(new MainViewModel());
            }
        }

        private void ShowGui(MainViewModel updateData)
        {
            MainWindow mainWindow = new MainWindow(updateData);
            mainWindow.Show();
        }

        private void ShowHelp(OptionSet p)
        {
            if (AttachConsole(AttachParentProcess))
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("FakeUpdate Options:");
                p.WriteOptionDescriptions(Console.Out);
                Console.WriteLine();
                Console.WriteLine("IMPORTANT:");
                Console.WriteLine(" - To use spaces in your text, wrap your text in quotes \"like this\".");
                Console.WriteLine();
                FreeConsole();
            }
            Shutdown();
        }
    }
}
