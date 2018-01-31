using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Converter
{
    class EntityModelConverter
    {
        public FlashCardCollectionModel ToFlashCardCollectionModel(FlashCardCollectionEntity entity)
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
    }
}
