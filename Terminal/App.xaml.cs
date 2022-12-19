using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tecan.Sila2.Server;
using CoCoME.Terminal.ViewModels;
using Common.Logging;
using System.ComponentModel;

namespace CoCoME.Terminal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Bootstrapper _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DelegateCommand.ExceptionHandler = ex => MessageBox.Show(ex.Message, "An error occured", MessageBoxButton.OK, MessageBoxImage.Error);
            ViewModelBase.PropertyChangedInvoker = DispatchPropertyChangedInvoker(ViewModelBase.PropertyChangedInvoker);
            LogManager.Adapter = new Common.Logging.Simple.DebugLoggerFactoryAdapter();
            _bootstrapper = new Bootstrapper();
            Bootstrapper.Start(e.Args, _bootstrapper);
        }

        private Action<ViewModelBase, PropertyChangedEventArgs> DispatchPropertyChangedInvoker(Action<ViewModelBase, PropertyChangedEventArgs> propertyChangedInvoker)
        {
            return (vm, e) => Dispatcher.Invoke(() => propertyChangedInvoker?.Invoke(vm, e));
        }

        protected override void OnActivated(EventArgs e)
        {
            MainWindow.DataContext = _bootstrapper.Container.GetExportedValue<MainViewModel>();
            base.OnActivated(e);
        }
    }
}
