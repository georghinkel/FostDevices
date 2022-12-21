using CoCoME.Terminal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly IBarcodeScannerViewModel _scannerViewModel;

        public BarcodeController(IBarcodeScannerViewModel scannerViewModel)
        {
            _scannerViewModel = scannerViewModel;
        }

        [HttpPost]
        public async Task SendBarcode()
        {
            var barcode = await (new StreamReader(Request.Body)).ReadToEndAsync();
            _scannerViewModel.Scan(barcode);
        }
    }
}
