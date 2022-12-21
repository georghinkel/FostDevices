using CoCoME.Terminal.ViewModels;
using CoCoME.Terminal.ViewModels.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashboxController : ControllerBase
    {
        private readonly ICashboxViewModel _cashBoxViewModel;

        public CashboxController(ICashboxViewModel cashBoxViewModel)
        {
            _cashBoxViewModel = cashBoxViewModel;
        }

        [HttpPost]
        public async Task PressButton()
        {
            var button = await (new StreamReader(Request.Body)).ReadToEndAsync();
            _cashBoxViewModel.PressButton(button);
        }
    }
}
