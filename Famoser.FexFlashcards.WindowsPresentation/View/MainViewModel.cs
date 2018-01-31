using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;
using GalaSoft.MvvmLight;

namespace Famoser.FexFlashcards.WindowsPresentation.View
{
    class MainViewModel : ViewModelBase
    {
        private readonly IFlashCardRepository _flashCardRepository;
        public MainViewModel(IFlashCardRepository flashCardRepository)
        {
            _flashCardRepository = flashCardRepository;
        }


    }
}
