using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeUpdate.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _title = "Configuring critical Windows Updates";
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

        private int _seconds = 5;
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

        private string _complete = "complete";
        public string Complete
        {
            get
            {
                return _complete;
            }
            set
            {
                SetProperty(ref _complete, value);
            }
        }

        private string _requestUpdating = "Do not turn off your PC";
        public string RequestUpdating
        {
            get
            {
                return _requestUpdating;
            }
            set
            {
                SetProperty(ref _requestUpdating, value);
            }
        }

        private string _completeCommand = string.Empty;
        public string CompleteCommand
        {
            get
            {
                return _completeCommand;
            }
            set
            {
                SetProperty(ref _completeCommand, value);
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

        private Random random = new Random();

        public async void IncreaseInRandom()
        {
            while (this.Progress < 100)
            {
                await Task.Delay(Seconds * 1000);
                Progress = random.Next(Progress + 1, Progress + 10 <= 100 ? Progress + 10
                    : 100);
            }
            await Task.Delay(5000);
            CompleteEvent?.Invoke();
        }
        public delegate void CompleteDelegate();

        public event CompleteDelegate CompleteEvent;
    }
}
