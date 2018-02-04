using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity.FexCompiler;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity.Statistics;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Converter
{
    class EntityModelConverter
    {
        public static FlashCardCollectionModel ToFlashCardCollectionModel(FlashCardCollectionEntity entity)
        {
            var coll = new FlashCardCollectionModel()
            {
                ChangedAt = entity.MetaDataModel.ChangedAt,
                Title = entity.MetaDataModel.Title,
                Hash = entity.MetaDataModel.Hash
            };

            foreach (var entityLearningCard in entity.LearningCards)
            {
                var learningCard = new FlashCardModel()
                {
                    Title = entityLearningCard.Title,
                    Content = entityLearningCard.Content,
                    ContentLineCount = entityLearningCard.ItemCount,
                    DifficultyLevel = 0,
                    Path = entityLearningCard.Path,
                    Hash = entityLearningCard.Identifier
                };

                coll.FlashCardModels.Add(learningCard);
            }

            return coll;
        }

        public static void AttachStatisticInfos(FlashCardCollectionModel model,
            FlashCardCollectionStatisticsEntity statistics)
        {
            model.RoundsCompleted = statistics.RoundsCompleted;
            model.TimesOpened = statistics.TimesOpened;
            model.CardsSeen = statistics.CardsSeen;

            //match cards with statistics
            var matchings = from t1 in model.FlashCardModels
                join t2 in statistics.FlashCardStatisticsEntity on t1.Hash equals t2.Hash
                select new { t1, t2 };

            var enumeratedMatchings = matchings.ToList();

            foreach (var matching in enumeratedMatchings)
            {
                matching.t1.DifficultyLevel = matching.t2.DifficultyLevel;
                matching.t1.TimesSeen = matching.t2.TimesPlayed;
            }


            var onlyModels = enumeratedMatchings.Select(e => e.t1);
            var newOnes = model.FlashCardModels.Where(s => !onlyModels.Contains(s));
            foreach (var flashCardModel in newOnes)
            {
                flashCardModel.IsNew = true;
            }
        }
    }
}
