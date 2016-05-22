using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using DatabaseApp.Models;
using System.Diagnostics;
using DatabaseApp.Controllers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DatabaseApp.ViewModels
{
   
    public sealed partial class Debts : Page
    {
        private ObservableCollection<DebtLoan> list = new ObservableCollection<DebtLoan>();
 
        public Debts()
        {
            this.InitializeComponent();
            


        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MoreFunctions));
        }

        private void OnItemClickHandlerDebts(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(IndiviualIncExp), e.ClickedItem);
        }
    }
}
