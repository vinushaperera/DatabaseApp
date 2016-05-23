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
                CommonController comCont = new CommonController();
                IncomeExpenseController ieCont = new IncomeExpenseController();

                String ieID = comCont.idGenerator("ie");
                String stID = comCont.idGenerator("st");
                
                IncExp incexp = new IncExp(savings.Name + "[Transaction]", amount, "default_null", "default_null", "Saving transaction - depost", ieID, "default_null", false, "AC_ID123");
                SmallTransactions sTrans = new SmallTransactions(amount, "", 'd', savings.Id, stID, date, "AC_ID123");
                SavingsController controller = new SavingsController();
                int status = controller.addDepositWithdraw(sTrans);
                int status2 = ieCont.addTransaction(incexp);
                int status3 = comCont.insertMoreIDs(ieID, savings.Id, stID);

                if (status == 1 && status2 == 1 && status3 == 1)
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
