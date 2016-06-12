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

        public ObservableCollection<DebtLoan> getAllDebts()
        {
            ObservableCollection<DebtLoan> list = new ObservableCollection<DebtLoan>();
            list = DatabaseHandler.getDebtLoanValues();

            ObservableCollection<DebtLoan> debtsList = new ObservableCollection<DebtLoan>();

            foreach(DebtLoan debt in list)
            {
                if(debt.Debt)
                {
                    debtsList.Add(debt);
                }
            }

            return debtsList;
        }
        public ObservableCollection<DebtLoan> getAllLoans()
        {
            ObservableCollection<DebtLoan> list = new ObservableCollection<DebtLoan>();
            list = DatabaseHandler.getDebtLoanValues();

            ObservableCollection<DebtLoan> loanList = new ObservableCollection<DebtLoan>();

            foreach (DebtLoan loan in list)
            {
                if (!(loan.Debt))
                {
                    loanList.Add(loan);
                }
            }

            return loanList;
        }
    }
}
