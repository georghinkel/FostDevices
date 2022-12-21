using System;

namespace CoCoME.Terminal.ViewModels
{
    public interface ICardReaderViewModel
    {
        string Display { get; set; }

        event EventHandler<CardDataEventArgs> TransactionAuthorized;

        event EventHandler Cancelled;

        void Authorize(string cardId);

        void Cancel();
    }
}