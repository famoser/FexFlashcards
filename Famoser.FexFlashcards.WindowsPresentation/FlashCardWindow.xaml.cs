using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Famoser.FexFlashcards.WindowsPresentation.Business.Models;
using Famoser.FexFlashcards.WindowsPresentation.Business.Repositories.Interfaces;
using Famoser.FexFlashcards.WindowsPresentation.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace Famoser.FexFlashcards.WindowsPresentation
{
    /// <summary>
    /// Interaction logic for FlashCardWindow.xaml
    /// </summary>
    public partial class FlashCardWindow : Window
    {
        public FlashCardWindow()
        {
            InitializeComponent();
        }

        public void SetFlashCardCollection(FlashCardCollectionModel collection, int selectedLevel)
        {
            ViewModel.SetFlashCardCollection(collection, selectedLevel);
        }

        private FlashCardViewModel ViewModel => DataContext as FlashCardViewModel;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Handled)
            {
                if (e.Key == Key.Left)
                    ViewModel.GoToPreviousCommand.Execute(null);
                if (e.Key == Key.Right)
                    ViewModel.GoToNextCommand.Execute(null);
                if (e.Key == Key.Up)
                    ViewModel.PutLevelUpCommand.Execute(null);
                if (e.Key == Key.Down)
                    ViewModel.PutLevelDownCommand.Execute(null);
                if (e.Key == Key.Space)
                    ViewModel.ShowBackSideCommand.Execute(null);
                if (e.Key == Key.Escape)
                    this.Close();
            }
        }
    }
}
