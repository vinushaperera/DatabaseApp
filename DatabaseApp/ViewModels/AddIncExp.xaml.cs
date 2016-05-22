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
    
    public sealed partial class AddIncExp : Page
    {
        private bool cond = false;
        private IncExp incexp1 = null;

        public AddIncExp()
        {
            this.InitializeComponent();
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                incexp1 = (IncExp)e.Parameter;
                tName_box.Text = incexp1.Name;
                tAmount_box.Text = incexp1.Amount.ToString();

                if (incexp1.Person.Equals("default_null")) {
                    tPerson_box.Text = "";
                }
                else
                {
                    tPerson_box.Text = incexp1.Person;
                }

                if (incexp1.Description.Equals("default_null"))
                {
                    tDesc_box.Text = "";
                }
                else
                {
                    tDesc_box.Text = incexp1.Description;
                }
                
                //testing_box = incexp1.Category;
                tDate_box.Date = Convert.ToDateTime(incexp1.Date);

                if (incexp1.Income) {
                    tIncome_radio.IsChecked = true;
                }
                else
                {
                    tExpense_radio.IsChecked = true;
                }

                cond = true;
            }

        }

        private async void tAdd_btn_Click(object sender, RoutedEventArgs e)
        {

            String name = tName_box.Text;
            double amount = 0.0;
            if (!(tAmount_box.Text.Equals("")))
            {
                amount = Convert.ToDouble(tAmount_box.Text);
            }
            String payer = "default_null";
            if (!(tPerson_box.Text.Equals("")))
            {
                payer = tPerson_box.Text;
            }
            
            bool income_radio = (bool)tIncome_radio.IsChecked;
            bool expense_radio = (bool)tExpense_radio.IsChecked;

            String category = "default_null";
            //String category = testing_box.Text;
            String desc = "default_null";
            if (!(tDesc_box.Text.Equals("")))
            {
                desc = tDesc_box.Text;
            }
            String date = tDate_box.Date.ToString();

            if (name.Equals("") || name == null)
            {
                MessageDialog msg = new MessageDialog("Transaction name cannot be empty!");
                await msg.ShowAsync();
            }
            else if (amount == 0.0)
            {
                MessageDialog msg = new MessageDialog("Amount cannot be 0!");
                await msg.ShowAsync();
            }
            else if (amount < 0)
            {
                MessageDialog msg = new MessageDialog("Amount cannot be less than 0!");
                await msg.ShowAsync();
            }
            else if (!(income_radio || expense_radio))
            {
                MessageDialog msg = new MessageDialog("Please select the type!");
                await msg.ShowAsync();
            }
            else
            {
                bool incExpCond = false;
                if (income_radio)
                {
                    incExpCond = true;
                }
                IncExp incExp = new IncExp(name, amount, payer, category, desc, "ID123", date, incExpCond, "AC_ID123");
                IncomeExpenseController controller = new IncomeExpenseController();

                if (cond) {
                    int status = controller.updateTransaction(incExp);

                    if(status == 1)
                    {
                        MessageDialog msg = new MessageDialog("Updated successfully!");
                        await msg.ShowAsync();
                        Frame.Navigate(typeof(IndiviualIncExp), incExp);
                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("Failed to update!");
                        await msg.ShowAsync();
                        Frame.Navigate(typeof(IncExpTransactions));
                    }

                    
                } else
                {
                    int status = controller.addTransaction(incExp);

                    if(status == 1)
                    {
                        MessageDialog msg = new MessageDialog("Added successfully!");
                        await msg.ShowAsync();
                        Frame.Navigate(typeof(MainView));
                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("Failed to add!");
                        await msg.ShowAsync();
                        Frame.Navigate(typeof(MainView));
                    }

                    
                }
                

                
            }

            
            
        }

        private void tCancel_btn_Click(object sender, RoutedEventArgs e)
        {
            if(incexp1 == null)
            {
                Frame.Navigate(typeof(MainView));
            }
            else
            {
                Frame.Navigate(typeof(IndiviualIncExp), incexp1);
            }
        }
    }
}
