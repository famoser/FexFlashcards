using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Entity
{
    class FlashCardCollectionEntity
    {
        public StatisticEntity StatisticModel { get; set; }
        public MetaDataEntity MetaDataModel { get; set; }
        public List<FlashCardEntity> LearningCards { get; set; }
    }
}
