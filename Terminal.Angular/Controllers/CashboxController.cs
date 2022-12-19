using CoCoME.Terminal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashboxController : ControllerBase
    {
        private readonly CashboxViewModel _cashBoxViewModel;

        public CashboxController(CashboxViewModel cashBoxViewModel)
        {
            _cashBoxViewModel = cashBoxViewModel;
        }

        [HttpPost]
        public void PressButton( [FromBody] string button)
        {
            _cashBoxViewModel.PressButton(button);
        }
    }
}
