using FakeUpdate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeUpdate.Models
{
    [Update(typeof(Windows7UpdateWindow))]
    public class Windows7Update : UpdateBase
    {
        public Windows7Update()
        {
            ForegroundColor = new EditbleColor(System.Windows.Media.Colors.White);
            BackgroundColor = new EditbleColor(System.Windows.Media.Colors.White);
            Style = "Windows 7 Update";
            Title = "Configuring updates";
            UpdatingRequest = "Do not turn off your PC";
            Indicator = "complete";
            Seconds = 3;
        }
    }
}
