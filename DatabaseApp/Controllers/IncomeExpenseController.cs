using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DatabaseApp.Models;
using System.Diagnostics;
using Windows.UI.Popups;

namespace DatabaseApp.Controllers
{
    public class IncomeExpenseController
    {
        public int addTransaction(IncExp incExp)
        {
            int status = DatabaseHandler.insertIncome(incExp);

            if(status == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int updateTransaction(IncExp incexp)
        {
            int status = DatabaseHandler.updateIncome(incexp);

            if (status == 1)
            {
                return 1;
            }
            else {
                return 0;        
            }

        }

        public SeperateDetails incomeExpenseTotal() {
            ObservableCollection<IncExp> list = new ObservableCollection<IncExp>();
            list = DatabaseHandler.getIncomeExpenseValues();

            double inc_value = 0.0;
            double exp_value = 0.0;
            double balance = 0.0;

            foreach (IncExp incExp in list)
            {
                if (incExp.Income == true)
                {
                    inc_value += incExp.Amount;
                }
                else {
                    exp_value += incExp.Amount;
                }
                
            }

            balance = inc_value - exp_value;

            SeperateDetails details = new SeperateDetails(inc_value, exp_value, balance);

            return details;
        }

        public ObservableCollection<IncExp> incomeExpenseList()
        {
            ObservableCollection<IncExp> list = new ObservableCollection<IncExp>();
            list = DatabaseHandler.getIncomeExpenseValues();

            return list;
        }

        public int deleteIncome(IncExp incExp) {
            int status = DatabaseHandler.deleteIncExp(incExp.Id);

            if(status == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
