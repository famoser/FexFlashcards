using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Mock
{
    class FlashCardRepositoryMock : IFlashCardRepository
    {
        private readonly Random _random = new Random();

        public ObservableCollection<FlashCardCollectionModel> GetFlashCardCollections()
        {
            return new ObservableCollection<FlashCardCollectionModel>()
            {
                GetRandomFlashCardCollection(),
                GetRandomFlashCardCollection(),
                GetRandomFlashCardCollection(),
                GetRandomFlashCardCollection(),
                GetRandomFlashCardCollection(),
            };
        }

        private FlashCardCollectionModel GetRandomFlashCardCollection()
        {
            return new FlashCardCollectionModel()
            {
                Hash = "my random hash",
                RoundsCompleted = _random.Next(),
                ChangedAt = new DateTime(2018, 1, 1),
                TimesOpened = _random.Next(),
                Title = "Network Security",
                FlashCardModels =
                {
                    GetRandomFlashCard(), GetRandomFlashCard(),
                    GetRandomFlashCard(), GetRandomFlashCard(),
                    GetRandomFlashCard(), GetRandomFlashCard()
                }
            };
        }

        private FlashCardModel GetRandomFlashCard()
        {
            return new FlashCardModel()
            {
                Hash = "my random hash",
                TimesSeen = _random.Next(),
                ContentLineCount = 2,
                Content = "mein text \nund hat text\nund hat text\nund hat text\nund hat text\nund hat text\nund hat text\nund hat text",
                DifficultyLevel = 0,
                Path = "Titel → Begriff → dinge",
                Title = "Network Security"
            };
        }

        public string GetBasePath()
        {
            return "D:\\Repos\\eth-2017-2\\Distributed Systems\\summary";
        }

        public void SetNewBasePath(string basePath)
        {
            //ignore
        }

        public void LoadFor(FlashCardCollectionModel flashCardCollectionModel)
        {
            //ignore
        }

        public void SaveFor(FlashCardCollectionModel flashCardCollectionModel)
        {
            //ignore
        }

        public void RefreshFlashCardCollections()
        {
            //ignore
        }
    }
}
