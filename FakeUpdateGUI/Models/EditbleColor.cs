using FakeUpdate.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FakeUpdate.Models
{
    public class EditbleColor : ViewModelBase
    {
        private Color _realColor;

        public Color RealColor
        {
            get
            {
                return _realColor;
            }
        }

        public byte R
        {
            get
            {
                return _realColor.R;
            }
            set
            {
                SetProperty(ref _realColor, Color.FromArgb(255, value, G, B));
            }
        }
        public byte G
        {
            get
            {
                return _realColor.G;
            }
            set
            {
                SetProperty(ref _realColor, Color.FromArgb(255, R, value, B));
            }
        }
        public byte B
        {
            get
            {
                return _realColor.B;
            }
            set
            {
                SetProperty(ref _realColor, Color.FromArgb(255, R, G, value));
            }
        }

        public EditbleColor(Color baseColor)
        {
            _realColor = baseColor;
        }

        public EditbleColor(byte red, byte green, byte blue)
        {
            _realColor = Color.FromArgb(255, red, green, blue);
        }
    }
}
