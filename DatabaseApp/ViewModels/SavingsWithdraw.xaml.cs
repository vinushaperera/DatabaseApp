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
            SavingsController cont = new SavingsController();
            double currentAmount = cont.savingsCurrentAmount(savings);
            if (Convert.ToDouble(wAmount_box.Text) > currentAmount)
            {
                MessageDialog msg = new MessageDialog("You don't have that much in your savings");
                await msg.ShowAsync();
            }
            else
            {
                double amount = Convert.ToDouble(wAmount_box.Text);
                String date = wDate_box.Date.ToString();

                IncomeExpenseController ieCont = new IncomeExpenseController();
                CommonController comCont = new CommonController();

                String wID = comCont.idGenerator("st");
                String ieID = comCont.idGenerator("ie");

                IncExp incexp = new IncExp(savings.Name + "[Transaction]", amount, "default_null", "default_null", "Saving transaction - withdraw", ieID, "default_null", true, "AC_ID123");
                SmallTransactions sTrans = new SmallTransactions(amount, "", 'w', savings.Id, wID, date, "AC_ID123");
                SavingsController controller = new SavingsController();

                int status = controller.addDepositWithdraw(sTrans);
                int status2 = ieCont.addTransaction(incexp);
                int status3 = comCont.insertMoreIDs(ieID, savings.Id, wID);

                if (status == 1 && status2 == 1 && status3 == 1)
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
}
