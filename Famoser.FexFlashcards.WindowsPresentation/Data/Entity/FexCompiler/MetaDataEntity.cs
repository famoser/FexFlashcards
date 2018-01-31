using System;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Entity.FexCompiler
{
    class MetaDataEntity
    {
        public DateTime GeneratedAt { get; set; }
        public DateTime ChangedAt { get; set; }
        public string Hash { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
    }
}
