using System.Collections.ObjectModel;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces
{
    interface IFlashCardRepository
    {
        ObservableCollection<FlashCardCollectionModel> GetFlashCardCollections();
        void RefreshFlashCardCollections();
        string GetBasePath();
        void SetNewBasePath(string basePath);

        void SaveFor(FlashCardCollectionModel flashCardCollectionModel);
    }
}
