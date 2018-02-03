using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity.Statistics;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Converter
{
    class ModelEntityConverter
    {
        public static FlashCardCollectionStatisticsEntity ConvertToFlashCardCollectionStatisticsEntity(FlashCardCollectionModel model)
        {
            var entity = new FlashCardCollectionStatisticsEntity()
            {
                Hash = model.Hash,
                TimesOpened = model.TimesOpened,
                TimesPlayed = model.RoundsCompleted
            };

            foreach (var modelFlashCardModel in model.FlashCardModels)
            {
                var flashEntity = new FlashCardStatisticsEntity()
                {
                    Hash = modelFlashCardModel.Hash,
                    TimesPlayed = modelFlashCardModel.TimesSeen,
                    DifficultyLevel = modelFlashCardModel.DifficultyLevel
                };

                entity.FlashCardStatisticsEntity.Add(flashEntity);
            }

            return entity;
        }

    }
}
