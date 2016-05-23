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
    public sealed partial class SavingsAdd : Page
    {
        bool update = false;
        String updateID;
        public SavingsAdd()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Savings saving = (Savings)e.Parameter;
            if(saving != null)
            {
                sAdd_label.Text = "Update Saving";
                saName_box.Text = saving.Name;
                saAmount_box.Text = saving.Goal.ToString();
                saStarting_box.Text = saving.Initial.ToString();
                saCreate_btn.Content = "Update"; 
                update = true;
                updateID = saving.Id;
            }

            
        }

        private async void saCreate_btn_Click(object sender, RoutedEventArgs e)
        {
            String name = saName_box.Text;
            double amount = 0.0;
            if (!(saAmount_box.Text.Equals("")))
            {
                amount = Convert.ToDouble(saAmount_box.Text);
            }

            double initial = 0.0;
            if (!(saStarting_box.Text.Equals("")))
            {
                initial = Convert.ToDouble(saStarting_box.Text);
            }

            if (name.Equals("") || name == null)
            {
                MessageDialog msg = new MessageDialog("Savings name cannot be empty!");
                await msg.ShowAsync();
            }
            else if (amount == 0.0)
            {
                MessageDialog msg = new MessageDialog("Goal amount cannot be 0!");
                await msg.ShowAsync();
            }
            else if (amount < 0)
            {
                MessageDialog msg = new MessageDialog("Goal amount cannot be less than 0!");
                await msg.ShowAsync();
            }
            else if (initial < 0)
            {
                MessageDialog msg = new MessageDialog("Initial amount cannot be less than 0!");
                await msg.ShowAsync();
            }
            else
            {
                CommonController contCom = new CommonController();
                String sID = contCom.idGenerator("sa");
                String ieID = contCom.idGenerator("ie");

                IncExp incexp = new IncExp(name + "[Savings]", initial, "default_null", "default_null", "Savings plan", ieID, "default_null", false, "AC_ID123"); 
                IncomeExpenseController ieCont = new IncomeExpenseController();
                
                Savings savings = new Savings(name, amount, initial, sID, "AC_ID123");
                SavingsController controller = new SavingsController();

                if (update)
                {
                    savings.Id = updateID;                    
                    String ieIDUpdate = contCom.idOtherCheck(updateID, "SAID");
                    incexp.Id = ieIDUpdate;
                    int status = controller.updateSaving(savings);
                    int status2 = ieCont.updateTransaction(incexp);

                    if (status == 1 && status2 == 1)
                    {
                        MessageDialog msg = new MessageDialog("Updated Successfully!");
                        await msg.ShowAsync();
                        Frame.Navigate(typeof(SavingsDetails), savings);
                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("Failed to update!");
                        await msg.ShowAsync();
                    }
                }
                else
                {
                    int status = ieCont.addTransaction(incexp);
                    int status1 = controller.addSavings(savings);
                    int status2 = contCom.insertIDs(incexp.Id, savings.Id);

                    if (status == 1 && status1 == 1 && status2 == 1)
                    {
                        MessageDialog msg = new MessageDialog("Added Successfully!");
                        await msg.ShowAsync();
                        Frame.Navigate(typeof(SavingsMainView));
                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("Failed to add!");
                        await msg.ShowAsync();
                    }
                }              
                
            }
        }

        private void saBack_btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SavingsMainView));
        }
    }
}
