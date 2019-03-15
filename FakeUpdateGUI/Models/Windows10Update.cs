using FakeUpdate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FakeUpdate.Models
{
    [Update(typeof(Windows10UpdateWindow))]
    public class Windows10Update : UpdateBase
    {
        public Windows10Update()
        {
            Seconds = 3;
            Indicator = "complete";
            Title = "Working on updates";
            Style = "Windows 10 Update";
            UpdatingRequest = "Do not turn off your PC";
            BackgroundColor = new EditbleColor(Color.FromArgb(255, 12, 112, 169));
            ForegroundColor = new EditbleColor(Colors.White);
        }



        public Windows10Update(UpdateBase parent)
        {
            Seconds = parent.Seconds;
            Indicator = parent.Indicator;
            Title = parent.Title;
            Style = parent.Style;
            Progress = parent.Progress;
            UpdatingRequest = parent.UpdatingRequest;
            BackgroundColor = parent.BackgroundColor;
            ForegroundColor = parent.ForegroundColor;
        }
    }
}
