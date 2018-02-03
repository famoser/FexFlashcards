using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Models
{
    public class FlashCardModel : ObservableObject
    {
        public string Hash { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ContentLineCount { get; set; }
        public string Path { get; set; }

        private int _timesSeen;
        public int TimesSeen
        {
            get => _timesSeen;
            set => Set(ref _timesSeen, value);
        }

        private bool _isNew;
        public bool IsNew
        {
            get => _isNew;
            set => Set(ref _isNew, value);
        }

        private int _difficultyLevel;
        public int DifficultyLevel
    {
            get => _difficultyLevel;
            set => Set(ref _difficultyLevel, value);
        }
    }
}
