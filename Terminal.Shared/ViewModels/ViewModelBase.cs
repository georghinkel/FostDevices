using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoCoME.Terminal.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public static Action<ViewModelBase, PropertyChangedEventArgs> PropertyChangedInvoker { get; set; } = InvokePropertyChanged;

        private static void InvokePropertyChanged(ViewModelBase instance, PropertyChangedEventArgs e)
        {
            instance.PropertyChanged?.Invoke(instance, e);
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChangedInvoker?.Invoke(this, new PropertyChangedEventArgs(property));
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
