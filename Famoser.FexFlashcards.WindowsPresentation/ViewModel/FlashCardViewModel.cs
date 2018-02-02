using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
                FlashCardCollection = _flashCardRepository.GetFlashCardCollections()[0];
                Level = 0;
                StartCommand.Execute(null);
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
            Level = selectedLevel;
        }

        public ICommand StartCommand
        {
            get => new RelayCommand(Start);
        }

        private void Start()
        {
            FlashCards = new ObservableCollection<FlashCardModel>(FlashCardCollection.FlashCardModels.Where(f => f.DifficultyLevel == Level));
            ActiveFlashcard = FlashCards.FirstOrDefault();
            ActiveFlashcardNumber = 1;
            TotalFlashcardNumber = FlashCards.Count;

            GoToNextCommand.RaiseCanExecuteChanged();
            PutLevelDownCommand.RaiseCanExecuteChanged();
            PutLevelUpCommand.RaiseCanExecuteChanged();
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
        }

        public RelayCommand PutLevelUpCommand
        {
            get => new RelayCommand(PutLevelUp, () => ActiveFlashcard != null);
        }

        private void PutLevelUp()
        {
            ActiveFlashcard.DifficultyLevel++;
            NavigateAway();
        }

        private void NavigateAway()
        {
            FlashCards.Remove(ActiveFlashcard);
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
            get => new RelayCommand(PutLevelDown, () => ActiveFlashcard != null && Level > 0);
        }

        private void PutLevelDown()
        {
            ActiveFlashcard.DifficultyLevel--;
            NavigateAway();
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

        private bool _showBackSide;
        public bool ShowBackSide
        {
            get => _showBackSide;
            set => Set(ref _showBackSide, value);
        }
    }
}
