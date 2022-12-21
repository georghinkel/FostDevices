using CoCoME.Terminal.ViewModels;
using CoCoME.Terminal.ViewModels.Contracts;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel;
using System.Reflection;

namespace Terminal.Angular.HubConfig
{
    public class HubSetup : IIntegrationComponent
    {
        private readonly IHubContext<TerminalHub> _hubContext;
        private readonly ICardReaderViewModel _cardReader;
        private readonly IDisplayViewModel _display;
        private readonly IPrinterViewModel _printer;

        public HubSetup(IHubContext<TerminalHub> hubContext, ICardReaderViewModel cardReader, IDisplayViewModel display, IPrinterViewModel printer)
        {
            _hubContext = hubContext;
            _cardReader = cardReader;
            _display = display;
            _printer = printer;
        }

        public void Start()
        {
            if (_cardReader is INotifyPropertyChanged notifyCardReader)
            {
                notifyCardReader.PropertyChanged += CardReaderPropertyChanged;
            }
            if (_display is INotifyPropertyChanged notifyDisplay)
            {
                notifyDisplay.PropertyChanged += DisplayPropertyChanged;
            }
            if (_printer is INotifyPropertyChanged notifyPrinter)
            {
                notifyPrinter.PropertyChanged += PrinterPropertyChanged;
            }
        }

        private void PrinterPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _hubContext.Clients.All.SendAsync("print", _printer.Print);
        }

        private void DisplayPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _hubContext.Clients.All.SendAsync("display", _display.Display);
        }

        private void CardReaderPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            _hubContext.Clients.All.SendAsync("cardReaderDisplay", _cardReader.Display);
        }
    }
}
