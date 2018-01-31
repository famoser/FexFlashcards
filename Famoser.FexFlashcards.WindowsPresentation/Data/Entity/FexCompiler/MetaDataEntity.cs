using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FexFlashcards.WindowsPresentation.Data.Entity
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
