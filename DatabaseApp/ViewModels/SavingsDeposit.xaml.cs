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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SavingsDeposit : Page
    {
        private Savings savings = new Savings();
        public SavingsDeposit()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            savings = (Savings)e.Parameter;
        }

        private async void dDeposit_btn_Click(object sender, RoutedEventArgs e)
        {
            double amount = Convert.ToDouble(dAmount_box.Text);
            String date = dDate_box.Date.ToString();


            if(amount == 0)
            {
                MessageDialog msg = new MessageDialog("Amount cannot be 0!");
                await msg.ShowAsync();
            }
            else if(amount < 0)
            {
                MessageDialog msg = new MessageDialog("Amount cannot be less than 0!");
                await msg.ShowAsync();
            }
            else
            {
                SmallTransactions sTrans = new SmallTransactions(amount, "", 'd', "SID123", "TransID123", date, "ACID123");
                SavingsController controller = new SavingsController();
                int status = controller.addDepositWithdraw(sTrans);

                if (status == 1)
                {
                    MessageDialog msg = new MessageDialog("Successfully deposited!");
                    await msg.ShowAsync();
                    Frame.Navigate(typeof(SavingsDetails), savings);
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Failed to deposit!");
                    await msg.ShowAsync();
                }
            }
            

        }

        private void dBack_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsDetails), savings);
        }
    }
}
