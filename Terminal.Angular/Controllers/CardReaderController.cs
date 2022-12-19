using CoCoME.Terminal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardReaderController : ControllerBase
    {
        private readonly CardReaderViewModel _cardReaderViewModel;

        public CardReaderController(CardReaderViewModel cardReaderViewModel)
        {
            _cardReaderViewModel = cardReaderViewModel;
        }

        [HttpPost]
        public void SelectCard([FromBody] string cardId)
        {
            _cardReaderViewModel.Authorize(cardId);
        }

        [HttpDelete]
        public void Cancel()
        {
            _cardReaderViewModel.Cancel();
        }
    }
}
