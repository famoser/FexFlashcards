using System.Collections.Generic;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Entity.Statistics
{
    class FlashCardCollectionStatisticsEntity
    {
        public string Hash { get; set; }
        public int TimesOpened { get; set; }
        public int RoundsCompleted { get; set; }
        public List<FlashCardStatisticsEntity> FlashCardStatisticsEntity { get; } = new List<FlashCardStatisticsEntity>();
        public int CardsSeen { get; internal set; }
    }
}
