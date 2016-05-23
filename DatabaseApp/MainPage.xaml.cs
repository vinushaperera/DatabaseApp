using DatabaseApp.Controllers;
using DatabaseApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace DatabaseApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //DatabaseHandler.dropIncomeExpenseTable();
            //DatabaseHandler.dropExpenseTable();
            DatabaseHandler.createIncomeExpenseTable();
            DatabaseHandler.createDebtLoanTable();
            DatabaseHandler.createSavingsTable();
            DatabaseHandler.createSmallTransactionsTable();
            DatabaseHandler.createIDTrackingTable();
            //IncomeExpenseController cont = new IncomeExpenseController();
            //Debug.WriteLine(cont.incomeTotal());
            Frame.Navigate(typeof(MainView));
        }
    }
}
