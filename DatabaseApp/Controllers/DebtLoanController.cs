using DatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Controllers
{
    public class DebtLoanController
    {
        public void addDebtLoan(DebtLoan debtLoan)
        {
            DatabaseHandler.insertDebtLoan(debtLoan);
        }
        public void addPayDebt(SmallTransactions sTrans)
        {
            DatabaseHandler.insertSmallTransactions(sTrans);
        }

        public ObservableCollection<DebtLoan> debtLoan()
        {
            ObservableCollection<DebtLoan> list = new ObservableCollection<DebtLoan>();
            list = DatabaseHandler.getDebtLoanValues();

            
            return list;
        }
    }
}
