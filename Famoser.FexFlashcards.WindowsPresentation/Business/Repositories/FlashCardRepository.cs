using System.Collections.ObjectModel;
using System.IO;
using Famoser.FexFlashcards.WindowsPresentation.Business.Helpers;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;
using Famoser.FexFlashcards.WindowsPresentation.Data;
using Famoser.FexFlashcards.WindowsPresentation.Data.Converter;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity.FexCompiler;
using Famoser.FexFlashcards.WindowsPresentation.Data.Entity.Statistics;
using Newtonsoft.Json;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Repositories
{
    class FlashCardRepository : IFlashCardRepository
    {
        private readonly ObservableCollection<FlashCardCollectionModel> _flashCardCollectionModels = new ObservableCollection<FlashCardCollectionModel>();
        private ConfigurationEntity _configurationEntity;

        public FlashCardRepository()
        {
            ReadConfiguration();
        }

        public ObservableCollection<FlashCardCollectionModel> GetFlashCardCollections()
        {
            return _flashCardCollectionModels;
        }

        public string GetBasePath()
        {
            return _configurationEntity.BasePath;
        }

        public void SetNewBasePath(string basePath)
        {
            if (_configurationEntity.BasePath != basePath)
            {
                _configurationEntity.BasePath = basePath;
                PersistConfiguration();
                RefreshFlashCardCollections();
            }
        }

        public void RefreshFlashCardCollections()
        {
            _flashCardCollectionModels.Clear();
            if (_configurationEntity.BasePath != null)
            {
                var files = Directory.GetFiles(_configurationEntity.BasePath, "*_version.json", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var realFile = file.Replace("_version.json", ".json");
                    if (File.Exists(realFile))
                    {
                        var json = File.ReadAllText(realFile);
                        var collection = JsonConvert.DeserializeObject<FlashCardCollectionEntity>(json);
                        var collectionModel = EntityModelConverter.ToFlashCardCollectionModel(collection);
                        collectionModel.CardsHistoryPath = realFile.Replace(".json", "_cards_history.json");
                        if (File.Exists(collectionModel.CardsHistoryPath))
                        {
                            var json2 = File.ReadAllText(collectionModel.CardsHistoryPath);
                            var statistics = JsonConvert.DeserializeObject<FlashCardCollectionStatisticsEntity>(json2);
                            EntityModelConverter.AttachStatisticInfos(collectionModel, statistics);
                        }
                        _flashCardCollectionModels.Add(collectionModel);
                    }
                }
            }
        }

        private const string ConfigFileName = "config.json";

        private void ReadConfiguration()
        {
            //read out existing or create new config model
            string configFilePath = Path.Combine(PathHelper.GetAssemblyPath(), ConfigFileName);
            if (File.Exists(configFilePath))
            {
                var configFileContent = File.ReadAllText(configFilePath);
                _configurationEntity = JsonConvert.DeserializeObject<ConfigurationEntity>(configFileContent);
            }
            else
            {
                _configurationEntity = new ConfigurationEntity();
            }
        }

        private void PersistConfiguration()
        {
            //save file
            string configFilePath = Path.Combine(PathHelper.GetAssemblyPath(), ConfigFileName);
            File.WriteAllText(configFilePath, JsonConvert.SerializeObject(_configurationEntity));
        }

        public void LoadFor(FlashCardCollectionModel flashCardCollectionModel)
        {
            flashCardCollectionModel.TimesOpened += 1;
        }

        public void SaveFor(FlashCardCollectionModel flashCardCollectionModel)
        {
            var statistics = ModelEntityConverter.ConvertToFlashCardCollectionStatisticsEntity(flashCardCollectionModel);
            File.WriteAllText(flashCardCollectionModel.CardsHistoryPath, JsonConvert.SerializeObject(statistics));
        }
    }
}
