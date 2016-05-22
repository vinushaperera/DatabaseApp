using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Models
{
    public class SeperateDetails
    {
        private double income;
        private double expense;
        private double debts;
        private double loans;
        private double savings;
        private double balance;

        public SeperateDetails()
        {

        }

        public SeperateDetails(double income, double expense, double balance)
        {
            this.income = income;
            this.expense = expense;
            this.balance = balance;
        }

        public double Income
        {
            get
            {
                return income;
            }

            set
            {
                income = value;
            }
        }

        public double Expense
        {
            get
            {
                return expense;
            }

            set
            {
                expense = value;
            }
        }
        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }




    }
}
