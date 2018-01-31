using System.Collections.Generic;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Entity.FexCompiler
{
    class FlashCardCollectionEntity
    {
        public StatisticEntity StatisticModel { get; set; }
        public MetaDataEntity MetaDataModel { get; set; }
        public List<FlashCardEntity> LearningCards { get; set; }
    }
}
