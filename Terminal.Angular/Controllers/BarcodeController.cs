using CoCoME.Terminal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly BarcodeScannerViewModel _scannerViewModel;

        public BarcodeController(BarcodeScannerViewModel scannerViewModel)
        {
            _scannerViewModel = scannerViewModel;
        }

        [HttpPost]
        public void SendBarcode([FromBody] string barcode)
        {
            _scannerViewModel.Scan(barcode);
        }
    }
}
