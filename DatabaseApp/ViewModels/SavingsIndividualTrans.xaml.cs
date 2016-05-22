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
    
    public sealed partial class SavingsIndividualTrans : Page
    {
        private SmallTransactions st = new SmallTransactions();
        public SavingsIndividualTrans()
        {
            this.InitializeComponent();
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            st = (SmallTransactions)e.Parameter;
            indiTransAmountBox.Text = "Rs." + st.Amount.ToString() + ".00";
            indiTransDateBox.Text = st.Date;
        }

        private void indiTransBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsMainView));
        }

        private async void indiTransDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            SavingsController controller = new SavingsController();
            int status = controller.deleteTransaction(st.Transaction_id);

            if (status == 1) {
                MessageDialog message = new MessageDialog("Successfully deleted!");
                await message.ShowAsync();
                                
            }
            else
            {
                MessageDialog message = new MessageDialog("Failed to delete!");
                await message.ShowAsync();
            }

            Frame.Navigate(typeof(SavingsMainView));    
        }
    }
}
