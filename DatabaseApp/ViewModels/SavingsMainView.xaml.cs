using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using DatabaseApp.Models;
using DatabaseApp.Controllers;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DatabaseApp.ViewModels
{
    
    public sealed partial class SavingsMainView : Page
    {
        public SavingsMainView()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SavingsController controller = new SavingsController();
            ObservableCollection<Savings> list = controller.allSavings();
            listView.ItemsSource =  list;
        }

        private void OnItemClickHandler(object sender, ItemClickEventArgs e) {
            Frame.Navigate(typeof(SavingsDetails), e.ClickedItem);
        }

        private void smNew_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsAdd));
        }

        private void smBack_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MoreFunctions));
        }
    }
}
