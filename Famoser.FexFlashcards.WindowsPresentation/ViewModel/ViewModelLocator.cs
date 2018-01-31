/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Famoser.FexFlashcards.WindowsPresentation"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Mock;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Famoser.FexFlashcards.WindowsPresentation.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IFlashCardRepository, FlashCardRepositoryMock>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IFlashCardRepository, FlashCardRepository>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FlashCardViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public FlashCardViewModel FlashCardViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FlashCardViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}