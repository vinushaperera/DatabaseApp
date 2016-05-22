using DatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DatabaseApp.Controllers
{
    public class SavingsController
    {
        public int addSavings(Savings savings)
        {
            return DatabaseHandler.insertSavings(savings);
            
        }

        public int addDepositWithdraw(SmallTransactions trans)
        {
            return DatabaseHandler.insertSmallTransactions(trans);            
        }

        public double savingsCurrentAmount(Savings savings) {

            ObservableCollection<SmallTransactions> collection = DatabaseHandler.getSmallTransactionValues();
            double deposit = 0.0;
            double withdraw = 0.0;
            String type;

            foreach(SmallTransactions st in collection)
            {
                if(st.Id.Equals(savings.Id))
                {
                    type = st.Type.ToString();
                    if(type.Equals("d"))
                    {
                        deposit += st.Amount;
                    }else if(type.Equals("w"))
                    {
                        withdraw += st.Amount;
                    }
                }
            }

            double balance = (savings.Initial + deposit) - withdraw;
            Debug.WriteLine("Deposit : " + deposit + "Withdraw : " + withdraw);
            
            return balance;
        }

        public int deleteTransaction(String id)
        {
            return DatabaseHandler.deleteSmallTrans(id);           
        }

        public ObservableCollection<Savings> allSavings()
        {
            ObservableCollection<Savings> list = DatabaseHandler.getSavingsValues();
            return list;
        }

        public ObservableCollection<SmallTransactions> allTransactions(String id)
        {
            ObservableCollection<SmallTransactions> list = DatabaseHandler.getSmallTransactionValues();
            ObservableCollection<SmallTransactions> listNew = new ObservableCollection<SmallTransactions>();

            foreach (SmallTransactions st in list)
            {
                if ((st.Id.Equals(id)) && (st.Type.ToString().Equals("d") || st.Type.ToString().Equals("w"))) {
                    listNew.Add(st);
                }
            }

            return listNew;
        }

        public int deleteSaving(String id)
        {
            return DatabaseHandler.deleteSaving(id);     
        }
        public int deleteSavingTransactions(String id)
        {
            return DatabaseHandler.deleteSavingsTransactions(id);
        }

        public int updateSaving(Savings saving)
        {
            return DatabaseHandler.updateSaving(saving);
        }
    }
}
