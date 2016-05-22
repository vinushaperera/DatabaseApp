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
    public sealed partial class DebtAddView : Page
    {
        public DebtAddView()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void dAdd_btn_Click(object sender, RoutedEventArgs e)
        {
            
            double amount = 0.0;
            if (!(dAmount_box.Text.Equals("")))
            {
                amount = Convert.ToDouble(dAmount_box.Text);
            }
            String payer = "default_null";
            if (!(dPerson_box.Text.Equals("")))
            {
                payer = dPerson_box.Text;
            }

            bool debt_radio = (bool)dDebt_radio.IsChecked;
            bool loan_radio = (bool)dLoan_radio.IsChecked;

           
            String desc = "default_null";
            if (!(dDesc_box.Text.Equals("")))
            {
                desc = dDesc_box.Text;
            }
            String date = dDate_box.Date.ToString();

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
            else if (!(debt_radio || loan_radio))
            {
                MessageDialog msg = new MessageDialog("Please select the type!");
                await msg.ShowAsync();
            } else if (payer.Equals("default_null"))
            {
                MessageDialog msg = new MessageDialog("Please enter a person!");
                await msg.ShowAsync();
            }
            else
            {
                bool debtLoanCond = false;
                if (debt_radio)
                {
                    debtLoanCond = true;
                }
                DebtLoan debtLoan = new DebtLoan(amount, payer, desc, "DLID123", date, debtLoanCond, "AC_ID123");
                DebtLoanController controller = new DebtLoanController();
                controller.addDebtLoan(debtLoan);
            }   
        }
    }
}
