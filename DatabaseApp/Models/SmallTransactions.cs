using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Models
{
    public class SmallTransactions
    {
        private double amount;
        private String description;
        private char type;
        private String id;
        private String transactionID;
        private String date;
        private String accID;

        public SmallTransactions() {

        }

        public SmallTransactions(double amount, String description, char type, String id, String transactionID, String date, String accID) {
            this.amount = amount;
            this.description = description;
            this.type = type;
            this.id = id;
            this.transactionID = transactionID;
            this.date = date;
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

        public char Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
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

        public string Transaction_id
        {
            get
            {
                return transactionID;
            }

            set
            {
                transactionID = value;
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
            return "Amount : " + Amount + "      Date : " + Date + " ";
        }
    }
}
