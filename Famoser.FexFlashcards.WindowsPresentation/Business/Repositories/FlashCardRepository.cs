using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Famoser.FexFlashcards.WindowsPresentation.Business.Helpers;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Data;
using Newtonsoft.Json;

namespace Famoser.FexFlashcards.WindowsPresentation.Business.Repositories
{
    class FlashCardRepository
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

        public void SetNewBasePath(string basePath)
        {
            _configurationEntity.BasePath = basePath;
            PersistConfiguration();
            FindFlashCardCollections();
        }

        public void FindFlashCardCollections()
        {
            _flashCardCollectionModels.Clear();
            if (_configurationEntity.BasePath != null)
            {
                var files = Directory.GetFiles(_configurationEntity.BasePath, "*_version.json", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    
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
            _configurationEntity = new ConfigurationEntity();
        }

        private void PersistConfiguration()
        {
            //save file
            string configFilePath = Path.Combine(PathHelper.GetAssemblyPath(), ConfigFileName);
            File.WriteAllText(configFilePath, JsonConvert.SerializeObject(_configurationEntity));
        }
    }
}
