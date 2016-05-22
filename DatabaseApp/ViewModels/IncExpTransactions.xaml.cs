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

namespace DatabaseApp.ViewModels
{
    
    public sealed partial class IncExpTransactions : Page
    {
        public IncExpTransactions()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IncomeExpenseController controller = new IncomeExpenseController();
            ObservableCollection<IncExp> list = controller.incomeExpenseList();

            ieListView.ItemsSource = list;
        }

        private void OnItemClickHandlerIE(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(IndiviualIncExp), e.ClickedItem);
        }

        private void ieTransactions_back_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainView));
        }
    }
}
