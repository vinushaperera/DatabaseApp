using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Models
{
    public class Savings
    {
        private String name;
        private double goal;
        private double initial;
        private String id;
        private String accID;
        

        public Savings() {

        }

        public Savings(String name, double goal, double initial, String id, String accID) {
            this.name = name;
            this.goal = goal;
            this.initial = initial;
            this.id = id;
            this.accID = accID;
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

        public double Goal
        {
            get
            {
                return goal;
            }

            set
            {
                goal = value;
            }
        }

        public double Initial
        {
            get
            {
                return initial;
            }

            set
            {
                initial = value;
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
            return ("Title : " + Name + "\nGoal : " + Goal);
        }
    }
}
