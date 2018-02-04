using System.Collections.ObjectModel;
using System.Linq;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Famoser.FexFlashcards.WindowsPresentation.ViewModel
{
    class FlashCardViewModel : ViewModelBase
    {
        private readonly IFlashCardRepository _flashCardRepository;

        public FlashCardViewModel(IFlashCardRepository flashCardRepository)
        {
            _flashCardRepository = flashCardRepository;

            if (IsInDesignModeStatic)
            {
                SetFlashCardCollection(_flashCardRepository.GetFlashCardCollections()[0], 0);
                ShowBackSide = true;
            }
        }

        private FlashCardCollectionModel _flashCardCollection;
        public FlashCardCollectionModel FlashCardCollection
        {
            get => _flashCardCollection;
            set => Set(ref _flashCardCollection, value);
        }

        private int _level;
        public int Level
        {
            get => _level;
            set => Set(ref _level, value);
        }

        internal void SetFlashCardCollection(FlashCardCollectionModel collection, int selectedLevel)
        {
            FlashCardCollection = collection;
            FlashCardCollection.TimesOpened++;
            Level = selectedLevel;

            //if -1, user clicked "only new"
            FlashCards = new ObservableCollection<FlashCardModel>(FlashCardCollection.FlashCardModels.Where(f => f.DifficultyLevel == Level));

            ActiveFlashcard = FlashCards.FirstOrDefault();
            ActiveFlashcardNumber = 1;
            TotalFlashcardNumber = FlashCards.Count;

            GoToNextCommand.RaiseCanExecuteChanged();
            PutLevelDownCommand.RaiseCanExecuteChanged();
            PutLevelUpCommand.RaiseCanExecuteChanged();
            ShowBackSideCommand.RaiseCanExecuteChanged();
            
            _flashCardRepository.SaveFor(FlashCardCollection);
        }

        public RelayCommand ShowBackSideCommand
        {
            get => new RelayCommand(() => ShowBackSide = !ShowBackSide);
        }

        public RelayCommand GoToNextCommand
        {
            get => new RelayCommand(GoToNext, () => FlashCards != null && ActiveFlashcardNumber < FlashCards.Count);
        }

        private void GoToNext()
        {
            ShowBackSide = false;
            ActiveFlashcard = FlashCards[ActiveFlashcardNumber];
            ActiveFlashcardNumber++;
            GoToNextCommand.RaiseCanExecuteChanged();

            //statistics
            ActiveFlashcard.TimesSeen++;
            FlashCardCollection.CardsSeen++;
            if (ActiveFlashcardNumber == FlashCards.Count)
            {
                FlashCardCollection.RoundsCompleted++;
            }
            _flashCardRepository.SaveFor(FlashCardCollection);
        }

        public RelayCommand GoToPreviousCommand
        {
            get => new RelayCommand(GoToPrevious, () => FlashCards != null && ActiveFlashcardNumber > 1);
        }

        private void GoToPrevious()
        {
            ShowBackSide = false;
            ActiveFlashcardNumber--;
            ActiveFlashcard = FlashCards[ActiveFlashcardNumber - 1];
            GoToPreviousCommand.RaiseCanExecuteChanged();

            //statistics
            FlashCardCollection.CardsSeen++;
            ActiveFlashcard.TimesSeen++;
            _flashCardRepository.SaveFor(FlashCardCollection);
        }

        public RelayCommand PutLevelUpCommand
        {
            get => new RelayCommand(PutLevelUp, () => ActiveFlashcard != null);
        }

        private void PutLevelUp()
        {
            ActiveFlashcard.DifficultyLevel++;
            DifficultyLevelChanged();
        }

        private void DifficultyLevelChanged()
        {
            _flashCardRepository.SaveFor(FlashCardCollection);
            FlashCards.Remove(ActiveFlashcard);
            TotalFlashcardNumber--;
            ActiveFlashcardNumber--;
            if (GoToNextCommand.CanExecute(null))
            {
                GoToNextCommand.Execute(null);
            }
            else if (GoToPreviousCommand.CanExecute(null))
            {
                GoToPreviousCommand.Execute(null);
            }
            else
            {
                ActiveFlashcard = null;
            }
        }

        public RelayCommand PutLevelDownCommand
        {
            get => new RelayCommand(PutLevelDown, () => ActiveFlashcard != null);
        }

        private void PutLevelDown()
        {
            ActiveFlashcard.DifficultyLevel--;
            DifficultyLevelChanged();
        }

        private FlashCardModel _activeFlashcard;
        public FlashCardModel ActiveFlashcard
        {
            get => _activeFlashcard;
            set => Set(ref _activeFlashcard, value);
        }

        private ObservableCollection<FlashCardModel> _flashCards;
        public ObservableCollection<FlashCardModel> FlashCards
        {
            get => _flashCards;
            set => Set(ref _flashCards, value);
        }

        private int _activeFlashcardNumber;
        public int ActiveFlashcardNumber
        {
            get => _activeFlashcardNumber;
            set => Set(ref _activeFlashcardNumber, value);
        }

        private int _totalFlashcardNumber;
        public int TotalFlashcardNumber
        {
            get => _totalFlashcardNumber;
            set => Set(ref _totalFlashcardNumber, value);
        }

        private int _jumpFlashcardNumber;
        public int JumpFlashcardNumber
        {
            get => _jumpFlashcardNumber;
            set => Set(ref _jumpFlashcardNumber, value);
        }

        private bool _showBackSide;
        public bool ShowBackSide
        {
            get => _showBackSide;
            set => Set(ref _showBackSide, value);
        }

        public RelayCommand JumpToFlashcardNumberCommand
        {
            get => new RelayCommand(JumpToFlashcardNumber, () => ActiveFlashcard != null);
        }

        private void JumpToFlashcardNumber()
        {
            ShowBackSide = false;
            ActiveFlashcardNumber = JumpFlashcardNumber;
            ActiveFlashcard = FlashCards[JumpFlashcardNumber - 1];
            GoToPreviousCommand.RaiseCanExecuteChanged();
            GoToNextCommand.RaiseCanExecuteChanged();

            //statistics
            FlashCardCollection.CardsSeen++;
            ActiveFlashcard.TimesSeen++;
            _flashCardRepository.SaveFor(FlashCardCollection);
        }
    }
}
