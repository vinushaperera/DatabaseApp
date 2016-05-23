﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApp.Controllers
{
    public class CommonController
    {
        public String idGenerator(String prefix) {

            String id = "";
            String idNew = null;
            int number = 10;

            if (prefix.Equals("ie"))
            {
                id = DatabaseHandler.getLastID("IncExp");
            }
            else if (prefix.Equals("sa"))
            {
                id = DatabaseHandler.getLastID("Savings");
            }
            else if (prefix.Equals("dl"))
            {
                id = DatabaseHandler.getLastID("DebtLoan");
            }
            else if (prefix.Equals("st"))
            {
                id = DatabaseHandler.getLastID("SmallTransactions");
            }
            
            if(id != "")
            {
                String[] idArray = id.Split(' ');
                number = Convert.ToInt32(idArray[1]);
                number++;

                idNew = idArray[0] + " " + number;
            }
            else
            {
                idNew = prefix + " " + number;
            }

            return idNew;
        }

        public int idCheck(String id)
        {
            String[] array = DatabaseHandler.findSpecificID(id);

            if(array[0] != null)
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
