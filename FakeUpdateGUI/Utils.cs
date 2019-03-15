using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeUpdate
{
    public static class Utils
    {
        public static void RunCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + command;
            Process.Start(startInfo);
        }
    }
}
