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
    
    public sealed partial class IndiviualIncExp : Page
    {
        private IncExp incexp = new IncExp();

        public IndiviualIncExp()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            incexp = (IncExp)e.Parameter;
            detailsIncExp_name.Text = incexp.Name;

            if (incexp.Income) {
                detailsIncExp_type.Text = "Income";
            }else
            {
                detailsIncExp_type.Text = "Expense";
            }

            detailsAmount.Text = incexp.Amount.ToString();

            if (incexp.Person.Equals("default_null"))
            {
                detailsPerson.Text = "";
            }
            else
            {
                detailsPerson.Text = incexp.Person;
            }
            
            detailsCategory.Text = incexp.Category;

            detailsDate.Text = incexp.Date;

            if (incexp.Description.Equals("default_null"))
            {
                detailsDesc.Text = "";
            }
            else
            {
                detailsDesc.Text = incexp.Description;
            }
                        

        }

        private void detailsBack_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainView));
        }

        private async void detailsEdit_btn_Click(object sender, RoutedEventArgs e)
        {
            CommonController controller = new CommonController();
            int status = controller.idCheck(incexp.Id);

            if(status == 1)
            {
                MessageDialog msg = new MessageDialog("You cannot edit this transaction here!");
                await msg.ShowAsync();
            }
            else
            {
                Frame.Navigate(typeof(AddIncExp), incexp);
            }
            
        }

        private async void detailsDelete_btn_Click(object sender, RoutedEventArgs e)
        {
            CommonController controller1 = new CommonController();
            int status1 = controller1.idCheck(incexp.Id);

            if (status1 == 1)
            {
                MessageDialog msg = new MessageDialog("You cannot delete this transaction here!");
                await msg.ShowAsync();
            }
            else
            {

                IncomeExpenseController controller = new IncomeExpenseController();
                int status = controller.deleteIncome(incexp);

                if (status == 1)
                {
                    MessageDialog message = new MessageDialog("Successfully Deleted!");
                    await message.ShowAsync();
                    Frame.Navigate(typeof(IncExpTransactions));
                }
                else
                {
                    MessageDialog message = new MessageDialog("Failed to delete!");
                    await message.ShowAsync();
                    Frame.Navigate(typeof(IncExpTransactions));
                }
            }
            
        }
    }
}
