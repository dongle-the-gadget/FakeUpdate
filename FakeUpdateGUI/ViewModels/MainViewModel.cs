using FakeUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeUpdate.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public List<UpdateBase> Updates
        {
            get
            {
                return new List<UpdateBase>()
                {
                    new Windows10Update(),
                    new Windows7Update()
                };
            }
        }

        private UpdateBase _selected;
        public UpdateBase SelectedUpdate
        {
            get
            {
                return _selected;
            }
            set
            {
                SetProperty(ref _selected, value);
            }
        }

        public MainViewModel()
        {
            SelectedUpdate = Updates[0];
        }
    }
}
