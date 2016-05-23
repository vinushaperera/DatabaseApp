using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Models
{
    public class IncExp
    {
        private String name;
        private double amount;
        private String person;
        private String category;
        private String description;
        private String id;
        private String date;
        private bool income;
        private String accID;

        public IncExp()
        {

        }

        public IncExp(String name, double amount, String person, String category,
            String desc, String id, String date, bool income, String accID)
        {
            this.name = name;
            this.amount = amount;
            this.person = person;
            this.category = category;
            this.description = desc;
            this.id = id;
            this.date = date;
            this.income = income;
            this.accID = accID;
        }

        public IncExp(String id)
        {
            this.id = id;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
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

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
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

        public bool Income
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
            String income = "Expense";

            if (Income) {
                income = "Income";
            }

            return ("Transaction : " + Name + " Amount : " + Amount + "  " + income);
        }
    }
}
