using DatabaseApp.Controllers;
using DatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    
    public sealed partial class SavingsWithdraw : Page
    {
        private Savings savings = new Savings();
        public SavingsWithdraw()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            savings = (Savings)e.Parameter;
        }

        private void wBack_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsDetails), savings);
        }

        private async void wWithdraw_btn_Click(object sender, RoutedEventArgs e)
        {
            double amount = Convert.ToDouble(wAmount_box.Text);
            String date = wDate_box.Date.ToString();

            SmallTransactions sTrans = new SmallTransactions(amount, "", 'w', "SID123", "TransID123", date, "ACID123");
            SavingsController controller = new SavingsController();
            int status = controller.addDepositWithdraw(sTrans);

            if (status == 1)
            {
                MessageDialog msg = new MessageDialog("Successfully withdrawed!");
                await msg.ShowAsync();
                Frame.Navigate(typeof(SavingsDetails), savings);
            }
            else
            {
                MessageDialog msg = new MessageDialog("Failed to withdraw!");
                await msg.ShowAsync();
            }

        }
    }
}
