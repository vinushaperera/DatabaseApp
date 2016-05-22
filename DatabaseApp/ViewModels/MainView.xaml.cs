using DatabaseApp.Controllers;
using DatabaseApp.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DatabaseApp.ViewModels
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();

            IncomeExpenseController controller = new IncomeExpenseController();
            SeperateDetails details = controller.incomeExpenseTotal();
            mainview_inflow_field.Text = "Rs. " + details.Income.ToString() + ".00";
            mainview_outflow_field.Text = "Rs. " + details.Expense.ToString() + ".00";
            mainview_balance_field.Text = "Rs. " + details.Balance.ToString() + ".00";

        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IncomeExpenseController controller = new IncomeExpenseController();
            SeperateDetails details = controller.incomeExpenseTotal();
            mainview_inflow_field.Text = "Rs. " + details.Income.ToString() + ".00";
            mainview_outflow_field.Text = "Rs. " + details.Expense.ToString() + ".00";
            mainview_balance_field.Text = "Rs. " + details.Balance.ToString() + ".00";

        }

        private void mainview_transaction_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddIncExp));
        }

        private void mainview_list_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(IncExpTransactions));
        }

        private void mainview_more_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MoreFunctions));
        }
    }
}
