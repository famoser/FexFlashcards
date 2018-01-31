using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Models
{
    class FlashCardModel : ObservableObject
    {
        public string Hash { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContentLineCount { get; set; }
        public string Path { get; set; }
        
        private int _timesPlayed;
        public int TimesPlayed
        {
            get => _timesPlayed;
            set => Set(ref _timesPlayed, value);
        }

        private int _difficultyLevel;
        public int DifficultyLevel
    {
            get => _difficultyLevel;
            set => Set(ref _difficultyLevel, value);
        }
    }
}
