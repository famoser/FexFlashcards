using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Models
{
    class FlashCardEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ItemCount { get; set; }
        public string Path { get; set; }
        public string Identifier { get; set; }
    }
}
