using FakeUpdate.ViewModels;
using FakeUpdate.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FakeUpdate.Models
{
    public class UpdateBase : ViewModelBase
    {
        public string GenerateCommandParameters()
        {
            string app = string.Empty;
            app +=  "\"" + Process.GetCurrentProcess().ProcessName + ".exe" + "\"";

            app += " --t=" + $"\"{Title}\"";
            app += " --i=" + $"\"{Indicator}\"";

            app += " --r=" + $"\"{UpdatingRequest}\"";

            app += " --br=" + BackgroundColor.R.ToString();
            app += " --bg=" + BackgroundColor.G.ToString();
            app += " --bb=" + BackgroundColor.B.ToString();
            app += " --fr=" + BackgroundColor.R.ToString();
            app += " --fg=" + BackgroundColor.G.ToString();
            app += " --fb=" + BackgroundColor.B.ToString();

            app += " --d=" + Seconds.ToString();

            if(!string.IsNullOrWhiteSpace(Command))
            {
                app += " --c=" + Command;
            }
            return app;
        }

        private EditbleColor _backgroundColor;

        public EditbleColor BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                SetProperty(ref _backgroundColor, value);
            }
        }

        private EditbleColor _foregroundColor;
        public EditbleColor ForegroundColor
        {
            get
            {
                return _foregroundColor;
            }
            set
            {
                SetProperty(ref _foregroundColor, value);
            }
        }

        private string _style;
        public string Style
        {
            get
            {
                return _style;
            }
            set
            {
                SetProperty(ref _style, value);
            }
        }

        private int _progress;
        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                SetProperty(ref _progress, value);
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private string _command;
        public string Command
        {
            get
            {
                return _command;
            }
            set
            {
                SetProperty(ref _command, value);
            }
        }

        private string _updatingRequest;
        public string UpdatingRequest
        {

            get
            {
                return _updatingRequest;
            }
            set
            {
                SetProperty(ref _updatingRequest, value);
            }
        }

        private string _indicator;
        public string Indicator
        {
            get
            {
                return _indicator;
            }
            set
            {
                SetProperty(ref _indicator, value);
            }
        }

        private int _seconds;
        public int Seconds
        {
            get
            {
                return _seconds;
            }
            set
            {
                SetProperty(ref _seconds, value);
            }
        }

        public delegate void UpdateCompleteEventHandler();

        public event UpdateCompleteEventHandler UpdateComplete;

        private Random random = new Random();

        public async void StartProgress()
        {
            while(Progress < 100)
            {
                await Task.Delay(Seconds * 1000);
                Progress = random.Next(Progress + 1, Progress + 10 < 100 ? Progress + 10 :
                    100);
            }
            await Task.Delay(5000);
            UpdateComplete?.Invoke();
        }
    }
}
