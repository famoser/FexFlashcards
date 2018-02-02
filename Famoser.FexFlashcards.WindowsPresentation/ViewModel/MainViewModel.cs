using System.Collections.ObjectModel;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using GalaSoft.MvvmLight;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity.FexCompiler;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Famoser.FexFlashcards.WindowsPresentation.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    class MainViewModel : ViewModelBase
    {
        private readonly IFlashCardRepository _flashCardRepository;
        public MainViewModel(IFlashCardRepository flashCardRepository)
        {
            _flashCardRepository = flashCardRepository;
            FlashCardCollections = flashCardRepository.GetFlashCardCollections();
            BasePath = flashCardRepository.GetBasePath();

            flashCardRepository.RefreshFlashCardCollections();
        }


        private string _basePath;
        public string BasePath
        {
            get => _basePath;
            set
            {
                if (Set(ref _basePath, value))
                {
                    _flashCardRepository.SetNewBasePath(_basePath);
                }
            }
        }


        public ObservableCollection<FlashCardCollectionModel> FlashCardCollections { get; set; }

        private FlashCardCollectionModel _selected;
        public FlashCardCollectionModel Selected
        {
            get => _selected;
            set
            {
                if (Set(ref _selected, value))
                {
                    if (_selected != null)
                    {
                        MaxLevel = Selected.FlashCardModels.Max(s => s.DifficultyLevel);
                    }
                }
            }
        }


        private int _maxLevel;
        public int MaxLevel
        {
            get => _maxLevel;
            set => Set(ref _maxLevel, value);
        }


        private int _selectedLevel;
        public int SelectedLevel
        {
            get => _selectedLevel;
            set => Set(ref _selectedLevel, value);
        }

        public ICommand StartTrainingCommand
        {
            get => new RelayCommand(StartTraining);
        }

        private void StartTraining()
        {
            FlashCardWindow window = new FlashCardWindow();
            window.SetFlashCardCollection(Selected, SelectedLevel);
            window.Show();
            Selected = null;
        }
    }
}