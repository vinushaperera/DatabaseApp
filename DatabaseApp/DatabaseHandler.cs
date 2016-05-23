using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.ObjectModel;
using SQLitePCL;
using System.Diagnostics;
using DatabaseApp.Models;

namespace DatabaseApp
{
    class DatabaseHandler
    {

        SQLitePCL.SQLiteConnection dbConn;

        //Create Tables

        public static void createIncomeExpenseTable()
        {
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"CREATE TABLE IF NOT EXISTS IncExp (
                                        Name NVARCHAR(50),
                                        Amount DOUBLE(20),
                                        Person NVARCHAR(60),
                                        Category NVARCHAR(60),
                                        Description NVARCHAR(200),
                                        ID NVARCHAR(10),
                                        Date NVARCHAR(20),
                                        Income TINYINT(1),
                                        Acc_ID NVARCHAR(10));"))
                {
                    statement.Step();
                }
            }
        }

        public static void createDebtLoanTable()
        {
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"CREATE TABLE IF NOT EXISTS DebtLoan (
                                        Amount DOUBLE(20),
                                        Person NVARCHAR(60),
                                        Description NVARCHAR(200),
                                        ID NVARCHAR(10),
                                        Date NVARCHAR(20),
                                        Debt TINYINT(1),
                                        Acc_ID NVARCHAR(10));"))
                {
                    statement.Step();
                }
            }
        }

        public static void createSavingsTable()
        {
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"CREATE TABLE IF NOT EXISTS Savings (
                                        Name NVARCHAR(50),    
                                        Goal DOUBLE(20),
                                        Initial DOUBLE(20),          
                                        ID NVARCHAR(10),
                                        Acc_ID NVARCHAR(10));"))
                {
                    statement.Step();
                }
            }
        }

        public static void createSmallTransactionsTable()
        {
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"CREATE TABLE IF NOT EXISTS SmallTransactions (
                                        Amount DOUBLE(20),
                                        Description NVARCHAR(200),
                                        Type NVARCHAR(10),
                                        ID NVARCHAR(10),
                                        TransactionID NVARCHAR(10),
                                        Date NVARCHAR(20),
                                        Acc_ID NVARCHAR(10));"))
                {
                    statement.Step();
                }
            }
        }

        public static void createIDTrackingTable()
        {
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"CREATE TABLE IF NOT EXISTS IDTracking (
                                        IEID NVARCHAR(10),
                                        DLID NVARCHAR(10),
                                        SAID NVARCHAR(10),
                                        STID NVARCHAR(10));"))
                {
                    statement.Step();
                }
            }
        }

        //Insert info

        public static int insertIncome(IncExp incExp)
        {
            int status = 0;
            String name = incExp.Name;
            double amount = incExp.Amount;
            String payer = incExp.Person;
            String category = incExp.Category;
            String description = incExp.Description;
            String id = incExp.Id;
            
            String[] dateArray = incExp.Date.ToString().Split(' ');
            String date = dateArray[0];

            bool isIncome = incExp.Income;
            int cond = 0;
            if (isIncome) {
                cond = 1;
            }
            String accID = incExp.AccID;

            try
            {
                using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
                {
                    using (var statement = connection.Prepare(@"INSERT INTO IncExp (Name, Amount, Person,
                                                                Category, Description, ID, Date, Income, Acc_ID)
                                    VALUES(?,?,?,?,?,?,?,?,?);"))
                    {
                        statement.Bind(1, name);
                        statement.Bind(2, amount.ToString());
                        statement.Bind(3, payer);
                        statement.Bind(4, category);
                        statement.Bind(5, description);
                        statement.Bind(6, id);
                        statement.Bind(7, date.ToString());
                        statement.Bind(8, cond);
                        statement.Bind(9, accID);


                        SQLiteResult s = statement.Step();
                        statement.Reset();
                        statement.ClearBindings();
                        if((s.ToString().Equals("DONE")))
                        {
                            Debug.WriteLine("Step done");
                            status = 1;                            
                        }
                        else
                        {
                            Debug.WriteLine("Step failed");
                            status = 0;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return status;
        }

        public static int insertDebtLoan(DebtLoan debtLoan)
        {
            int status = 0;
            double amount = debtLoan.Amount;
            String payer = debtLoan.Person;
            String description = debtLoan.Description;
            String id = debtLoan.Id;

            String[] dateArray = debtLoan.Date.ToString().Split(' ');
            String date = dateArray[0];

            bool isDebt = debtLoan.Debt;
            int cond = 0;
            if (isDebt)
            {
                cond = 1;
            }
            String accID = debtLoan.AccID;

            try
            {
                using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
                {
                    using (var statement = connection.Prepare(@"INSERT INTO DebtLoan (Amount, Person, 
                                                                Description, ID, Date, Debt, Acc_ID)
                                    VALUES(?,?,?,?,?,?,?);"))
                    {
                        statement.Bind(1, amount.ToString());
                        statement.Bind(2, payer);
                        statement.Bind(3, description);
                        statement.Bind(4, id);
                        statement.Bind(5, date.ToString());
                        statement.Bind(6, cond);
                        statement.Bind(7, accID);


                        SQLiteResult s = statement.Step();
                        statement.Reset();
                        statement.ClearBindings();
                        if ((s.ToString().Equals("DONE")))
                        {
                            Debug.WriteLine("Step done");
                            status = 1;
                        }
                        else
                        {
                            Debug.WriteLine("Step failed");
                            status = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return status;
        }

        public static int insertSavings(Savings savings)
        {
            int status = 0;
            String name = savings.Name;
            double goal = savings.Goal;
            double initial = savings.Initial;
            String id = savings.Id;
            String accID = savings.AccID;

            try
            {
                using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
                {
                    using (var statement = connection.Prepare(@"INSERT INTO Savings (Name, Goal, Initial,
                                                                ID, Acc_ID)
                                    VALUES(?,?,?,?,?);"))
                    {
                        statement.Bind(1, name);
                        statement.Bind(2, goal.ToString());
                        statement.Bind(3, initial.ToString());
                        statement.Bind(4, id);
                        statement.Bind(5, accID);


                        SQLiteResult s = statement.Step();
                        statement.Reset();
                        statement.ClearBindings();

                        if ((s.ToString().Equals("DONE")))
                        {
                            Debug.WriteLine("Step done");
                            status = 1;
                        }
                        else
                        {
                            Debug.WriteLine("Step failed");
                            status = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return status;
        }

        public static int insertSmallTransactions(SmallTransactions sTrans)
        {
            int status = 0;
            double amount = sTrans.Amount;
            String description = sTrans.Description;
            char type = sTrans.Type;
            String id = sTrans.Id;
            String trans_id = sTrans.Transaction_id;
            String[] dateArray = sTrans.Date.ToString().Split(' ');
            String date = dateArray[0];
            String accID = sTrans.AccID;

            try
            {
                using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
                {
                    using (var statement = connection.Prepare(@"INSERT INTO SmallTransactions (Amount, Description, Type,
                                                              ID, TransactionID, Date, Acc_ID)
                                                              VALUES(?,?,?,?,?,?,?);"))
                    {
                        statement.Bind(1, amount.ToString());
                        statement.Bind(2, description);
                        statement.Bind(3, type.ToString());
                        statement.Bind(4, id);
                        statement.Bind(5, trans_id);
                        statement.Bind(6, date);
                        statement.Bind(7, accID);

                        SQLiteResult s = statement.Step();
                        statement.Reset();
                        statement.ClearBindings();

                        if ((s.ToString().Equals("DONE")))
                        {
                            Debug.WriteLine("Step done");
                            status = 1;
                        }
                        else
                        {
                            Debug.WriteLine("Step failed");
                            status = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return status;
        }

        //Receive info

        public static ObservableCollection<IncExp> getIncomeExpenseValues()
        {
            ObservableCollection<IncExp> list = new ObservableCollection<IncExp>();

            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM IncExp;"))
                {

                    while (statement.Step() == SQLiteResult.ROW)
                    {

                        int value = Convert.ToInt16(statement[7]);
                        bool isIncome = false;
                        if (value == 1) {
                            isIncome = true;
                        }

                        list.Add(new IncExp()
                        {
                            Name = (String)statement[0],
                            Amount = double.Parse(statement[1].ToString()),                            
                            Person = (String)statement[2],
                            Category = (String)statement[3],
                            Description = (String)statement[4],
                            Id = (String)statement[5],
                            Date = (String)statement[6],
                            Income = isIncome,
                            AccID = (String)statement[8]
                        });                        
                    }
                }
            }
            return list;
        }

        public static ObservableCollection<DebtLoan> getDebtLoanValues()
        {
            ObservableCollection<DebtLoan> list = new ObservableCollection<DebtLoan>();

            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM DebtLoan;"))
                {

                    while (statement.Step() == SQLiteResult.ROW)
                    {

                        int value = Convert.ToInt16(statement[5]);
                        bool isDebt = false;
                        if (value == 1)
                        {
                            isDebt = true;
                        }

                        list.Add(new DebtLoan()
                        {
                            Amount = double.Parse(statement[0].ToString()),
                            Person = (String)statement[1],
                            Description = (String)statement[2],
                            Id = (String)statement[3],
                            Date = (String)(statement[4]),
                            Debt = isDebt,
                            AccID = (String)statement[6]
                        });
                    }
                }
            }
            return list;
        }

        public static ObservableCollection<Savings> getSavingsValues()
        {
            ObservableCollection<Savings> list = new ObservableCollection<Savings>();

            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM Savings;"))
                {

                    while (statement.Step() == SQLiteResult.ROW)
                    {
                        list.Add(new Savings()
                        {
                            Name = (String)statement[0],
                            Goal = double.Parse(statement[1].ToString()),
                            Initial = double.Parse(statement[2].ToString()),
                            Id = (String)statement[3],
                            AccID = (String)statement[4]
                        });
                    }
                }
            }
            return list;
        }

        public static ObservableCollection<SmallTransactions> getSmallTransactionValues()
        {
            ObservableCollection<SmallTransactions> list = new ObservableCollection<SmallTransactions>();

            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM SmallTransactions;"))
                {

                    while (statement.Step() == SQLiteResult.ROW)
                    {
                        list.Add(new SmallTransactions()
                        {
                            Amount = double.Parse(statement[0].ToString()),
                            Description = (String)statement[1],
                            Type = Convert.ToChar(statement[2].ToString()),
                            Id = (String)statement[3],
                            Transaction_id = (String)statement[4],
                            Date = (String)(statement[5]),
                            AccID = (String)statement[6]
                        });
                    }
                }
            }
            return list;
        }
        
        public static String getLastID(String table)
        {
            String id = "";

            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM " + table + " ORDER BY ID DESC LIMIT 1;"))
                {
                    if (table.Equals("IncExp"))
                    {
                        while (statement.Step() == SQLiteResult.ROW)
                        {
                            id = statement[5].ToString();
                        }
                    }
                    else if (table.Equals("Savings"))
                    {
                        while (statement.Step() == SQLiteResult.ROW)
                        {
                            id = statement[3].ToString();
                        }
                    }
                    else if (table.Equals("DebtLoan"))
                    {
                        while (statement.Step() == SQLiteResult.ROW)
                        {
                            id = statement[3].ToString();
                        }
                    }
                    else if (table.Equals("SmallTransactions"))
                    {
                        while (statement.Step() == SQLiteResult.ROW)
                        {
                            id = statement[3].ToString();
                        }
                    }
                }
            }
            return id;
        }

        //Update info

        public static int updateIncome(IncExp incExp) {

            int status = 0;
            String name = incExp.Name;
            double amount = incExp.Amount;
            String payer = incExp.Person;
            String category = incExp.Category;
            String description = incExp.Description;
            String id = incExp.Id;
            String date = incExp.Date;
            bool isIncome = incExp.Income;
            int cond = 0;
            if (isIncome)
            {
                cond = 1;
            }
            String accID = incExp.AccID;

            try
            {
                using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
                {
                    using (var statement = connection.Prepare(@"UPDATE IncExp SET Name=?, Amount=?, Person=?,
                                                                Category=?, Description=?, ID=?, Date=?, Income=?, Acc_ID=?
                                                                WHERE ID=?;"))
                    {
                        statement.Bind(1, name);
                        statement.Bind(2, amount.ToString());
                        statement.Bind(3, payer);
                        statement.Bind(4, category);
                        statement.Bind(5, description);
                        statement.Bind(6, id);
                        statement.Bind(7, date.ToString());
                        statement.Bind(8, cond);
                        statement.Bind(9, accID);
                        statement.Bind(10, id);


                        SQLiteResult s = statement.Step();
                        statement.Reset();
                        statement.ClearBindings();

                        if ((s.ToString().Equals("DONE")))
                        {
                            Debug.WriteLine("Update done");
                            status = 1;
                        }
                        else
                        {
                            Debug.WriteLine("Update failed");
                            status = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return status;
        }

        public static int updateSaving(Savings saving)
        {

            int status = 0;
            String name = saving.Name;
            double goal = saving.Goal;
            double initial = saving.Initial;
            String id = saving.Id;
            String accID = saving.AccID;

            try
            {
                using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
                {
                    using (var statement = connection.Prepare(@"UPDATE Savings SET Name=?, Goal=?, Initial=?,
                                                                ID=?, Acc_ID=?
                                                                WHERE ID=?;"))
                    {
                        statement.Bind(1, name);
                        statement.Bind(2, goal.ToString());
                        statement.Bind(3, initial.ToString());
                        statement.Bind(4, id);
                        statement.Bind(5, accID);
                        statement.Bind(6, id);


                        SQLiteResult s = statement.Step();
                        statement.Reset();
                        statement.ClearBindings();

                        if ((s.ToString().Equals("DONE")))
                        {
                            Debug.WriteLine("Update done");
                            status = 1;
                        }
                        else
                        {
                            Debug.WriteLine("Update failed");
                            status = 0;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return status;
        }

        //Delete info

        public static int deleteIncExp(String id)
        {
            int status = 0;
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"DELETE FROM IncExp WHERE ID=?;"))
                {
                    statement.Bind(1, id);
                    SQLiteResult s = statement.Step();

                    if ((s.ToString().Equals("DONE")))
                    {
                        Debug.WriteLine("Step done");
                        status = 1;
                    }
                    else
                    {
                        Debug.WriteLine("Step failed");
                        status = 0;
                    }
                }
            }

            return status;
        }

        public static int deleteSaving(String id)
        {
            int status = 0;
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"DELETE FROM Savings WHERE ID=?;"))
                {
                    statement.Bind(1, id);
                    SQLiteResult s = statement.Step();

                    if ((s.ToString().Equals("DONE")))
                    {
                        Debug.WriteLine("Step done");
                        status = 1;
                    }
                    else
                    {
                        Debug.WriteLine("Step failed");
                        status = 0;
                    }
                }
            }

            return status;
        }

        public static int deleteSavingsTransactions(String id)
        {
            int status = 0;
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"DELETE FROM SmallTransactions WHERE ID=?;"))
                {
                    statement.Bind(1, id);
                    SQLiteResult s = statement.Step();

                    if ((s.ToString().Equals("DONE")))
                    {
                        Debug.WriteLine("Step done");
                        status = 1;
                    }
                    else
                    {
                        Debug.WriteLine("Step failed");
                        status = 0;
                    }
                }
            }

            return status;
        }

        public static int deleteSmallTrans(String id)
        {
            int status = 0;
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"DELETE FROM SmallTransactions WHERE TransactionID=?;"))
                {
                    statement.Bind(1, id);
                    SQLiteResult s = statement.Step();

                    if ((s.ToString().Equals("DONE")))
                    {
                        Debug.WriteLine("Step done");
                        status = 1;
                    }
                    else
                    {
                        Debug.WriteLine("Step failed");
                        status = 0;
                    }
                }
            }

            return status;
        }

        //Delete table

        public static void dropIncomeExpenseTable()
        {
            using (var connection = new SQLitePCL.SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"DROP TABLE IncExp;"))
                {                                        
                    statement.Step();
                }
            }
        }


    }
}
