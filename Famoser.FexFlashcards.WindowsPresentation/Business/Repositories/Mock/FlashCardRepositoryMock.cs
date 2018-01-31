﻿using System;
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
                TimesPlayed = _random.Next(),
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
                TimesPlayed = _random.Next(),
                ContentLineCount = _random.Next(),
                Content = "mein text ist lage \nund hat textumbrüche",
                DifficultyLevel = _random.Next(),
                Path = "Titel -> Begriff -> dinge",
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
