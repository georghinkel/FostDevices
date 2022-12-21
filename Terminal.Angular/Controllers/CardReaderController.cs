using CoCoME.Terminal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Terminal.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardReaderController : ControllerBase
    {
        private readonly ICardReaderViewModel _cardReaderViewModel;

        public CardReaderController(ICardReaderViewModel cardReaderViewModel)
        {
            _cardReaderViewModel = cardReaderViewModel;
        }

        [HttpPost]
        public async Task SelectCard()
        {
            var cardId = await (new StreamReader(Request.Body)).ReadToEndAsync();
            _cardReaderViewModel.Authorize(cardId);
        }

        [HttpDelete]
        public void Cancel()
        {
            _cardReaderViewModel.Cancel();
        }
    }
}
