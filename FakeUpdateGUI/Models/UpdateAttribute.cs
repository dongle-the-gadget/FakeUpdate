using FakeUpdate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FakeUpdate.Models
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class UpdateAttribute : Attribute
    {
        public Type WindowType { get; set; }
        public UpdateAttribute(Type windowType)
        {
            WindowType = windowType;
        }
    }
    public static class UpdateExtensions
    {
        public static void ShowView(this UpdateBase update)
        {
            var attribute = update.GetType().GetCustomAttribute<UpdateAttribute>();
            if (attribute is null) throw new InvalidOperationException("No BluescreenViewAttribute has been found");
            var type = attribute.WindowType;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var window = (Window)Activator.CreateInstance(type, update);
                    window.Show();
                    update.StartProgress();
                    return window;
                });
        }
    }
}
