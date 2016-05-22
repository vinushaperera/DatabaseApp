using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Models
{
    public class DebtLoan
    {

        private double amount;
        private String person;
        private String description;
        private String id;
        private String date;
        private bool debt;
        private String accID;

        public DebtLoan() {

        }

        public DebtLoan(double amount, String person, String description, String id, String date, bool debt, String accID) {
            this.amount = amount;
            this.person = person;
            this.description = description;
            this.id = id;
            this.date = date;
            this.debt = debt;
            this.accID = accID;
        }

        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Person
        {
            get
            {
                return person;
            }

            set
            {
                person = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public String Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public bool Debt
        {
            get
            {
                return debt;
            }

            set
            {
                debt = value;
            }
        }

        public string AccID
        {
            get
            {
                return accID;
            }

            set
            {
                accID = value;
            }
        }

        public override string ToString()
        {
            return ("Amount : "+ Amount + " Person : "+ Person +"");
        }
    }


}
