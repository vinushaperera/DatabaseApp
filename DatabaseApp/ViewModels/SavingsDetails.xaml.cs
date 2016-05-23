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

    public sealed partial class SavingsDetails : Page
    {
        private Savings savings = new Savings();
        private bool savingsComplete = false;

        public SavingsDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            savings = (Savings)e.Parameter;
            double goal = savings.Goal;

            sName_block.Text = savings.Name;
            sGoal_block.Text = "Rs." + goal.ToString() + ".00";

            SavingsController controller = new SavingsController();
            

            double amount = controller.savingsCurrentAmount(savings);

            sAmount_block.Text = "Rs." + amount.ToString() + ".00";
            sLeft_block.Text = "Rs." + (goal - amount).ToString() + ".00";

            if(goal - amount == 0)
            {
                savingsComplete = true;
            }
        }

        private async void sDeposit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (savingsComplete)
            {
                MessageDialog msg = new MessageDialog("You have reached your goal!");
                await msg.ShowAsync();
            }
            else
            {
                Frame.Navigate(typeof(SavingsDeposit), savings);
            }
            
        }

        private void sWithdraw_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsWithdraw), savings);
        }

        private void sBack_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsMainView));
        }

        private void sTList_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsTransactions), savings);
        }

        private async void sDel_btn_Click(object sender, RoutedEventArgs e)
        {
            CommonController comCont = new CommonController();
            int status = comCont.deleteAllIEIDs(savings.Id);

            int status1 = comCont.deleteIDTrackRow(savings.Id);

            SavingsController controller = new SavingsController();
            int status2 = controller.deleteSavingTransactions(savings.Id);

            if(status == 1 && status1 == 1 && status2 == 1)
            {
                int status3 = controller.deleteSaving(savings.Id);

                if (status3 == 1)
                {
                    MessageDialog msg = new MessageDialog("Successfully deleted!");
                    await msg.ShowAsync();
                    Frame.Navigate(typeof(SavingsMainView));
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Failed to delete!");
                    await msg.ShowAsync();
                }
            }
            else
            {
                MessageDialog msg = new MessageDialog("Failed to delete!");
                await msg.ShowAsync();
            }


            
        }

        private void sEdit_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsAdd), savings);
        }
    }
}
