using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;
using GalaSoft.MvvmLight;

namespace Famoser.FexFlashcards.WindowsPresentation.ViewModel
{
    class FlashCardViewModel : ViewModelBase
    {
        private readonly IFlashCardRepository _flashCardRepository;

        public FlashCardViewModel(IFlashCardRepository flashCardRepository)
        {
            _flashCardRepository = flashCardRepository;
        }
        
        private FlashCardCollectionModel _flashCards;
        public FlashCardCollectionModel FlashCards
        {
            get => _flashCards;
            set => Set(ref _flashCards, value);
        }
    }
}
