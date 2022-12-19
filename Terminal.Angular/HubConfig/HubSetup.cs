using CoCoME.Terminal.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel;
using System.Reflection;

namespace Terminal.Angular.HubConfig
{
    public class HubSetup : IIntegrationComponent
    {
        private readonly IHubContext<TerminalHub> _hubContext;
        private readonly CardReaderViewModel _cardReader;
        private readonly DisplayViewModel _display;
        private readonly PrinterViewModel _printer;

        public HubSetup(IHubContext<TerminalHub> hubContext, CardReaderViewModel cardReader, DisplayViewModel display, PrinterViewModel printer)
        {
            _hubContext = hubContext;
            _cardReader = cardReader;
            _display = display;
            _printer = printer;
        }

        public void Start()
        {
            _cardReader.PropertyChanged += CardReaderPropertyChanged;
            _display.PropertyChanged += DisplayPropertyChanged;
            _printer.PropertyChanged += PrinterPropertyChanged;
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
