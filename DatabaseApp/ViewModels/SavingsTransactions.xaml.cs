using DatabaseApp.Controllers;
using DatabaseApp.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DatabaseApp.ViewModels
{
    
    public sealed partial class SavingsTransactions : Page
    {
        private Savings savings = new Savings();
        public SavingsTransactions()
        {
            this.InitializeComponent();
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            savings = (Savings)e.Parameter;
            SavingsController controller = new SavingsController();
            
            stransListView.ItemsSource = controller.allTransactions(savings.Id);
        }

        private void stransListView_ItemClick(object sender, ItemClickEventArgs e)
        {            
            Frame.Navigate(typeof(SavingsIndividualTrans), e.ClickedItem);
        }

        private void stransBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsDetails), savings);
        }
    }
}
