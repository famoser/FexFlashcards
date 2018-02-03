using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Models
{
    public class FlashCardCollectionModel : ObservableObject
    {
        public string Hash { get; set; }
        public string Title { get; set; }
        public DateTime ChangedAt { get; set; }
        public ObservableCollection<FlashCardModel> FlashCardModels { get; } = new ObservableCollection<FlashCardModel>();

        private int _timesOpened;
        public int TimesOpened
        {
            get => _timesOpened;
            set => Set(ref _timesOpened, value);
        }

        private int _roundsCompleted;
        public int RoundsCompleted
        {
            get => _roundsCompleted;
            set => Set(ref _roundsCompleted, value);
        }

        private int _cardsSeen;
        public int CardsSeen
        {
            get => _cardsSeen;
            set => Set(ref _cardsSeen, value);
        }

        public string CardsHistoryPath { get; set; }
    }
}
