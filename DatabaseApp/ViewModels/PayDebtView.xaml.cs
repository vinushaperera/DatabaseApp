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
using System.Collections.ObjectModel;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DatabaseApp.ViewModels
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PayDebtView : Page
    {
        public PayDebtView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private async void dPay_btn_Click(object sender, RoutedEventArgs e)
        {
            
            double amount = 0.0;
            if (!(dPayAmount_box.Text.Equals("")))
            {
                amount = Convert.ToDouble(dPayAmount_box.Text);
            }
            
            String date = dPayDate_box.Date.ToString();

            if (amount == 0.0)
            {
                MessageDialog msg = new MessageDialog("Amount cannot be 0!");
                await msg.ShowAsync();
            } 
            else if (amount < 0)
            {
                MessageDialog msg = new MessageDialog("Amount cannot be less than 0!");
                await msg.ShowAsync();
            }
            else
            {
                SmallTransactions sTrans = new SmallTransactions(amount, "Debt payment", 'd', "DID_123", "DPID_123", date, "AC_ID123");
                DebtLoanController controller = new DebtLoanController();
                controller.addPayDebt(sTrans);
            }


        }
    }
}
