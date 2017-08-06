using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibHomeBudget.Operations;

namespace AppInitializeDb
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Initializating Categories...");
            //LibHomeBudget.InitializeDB.InitializeCategories();
            // Console.Write("Done!");
            //Console.WriteLine("adding new user...");
            //LibHomeBudget.Operations.UserOperations.CreateNewUser("Andrzej", "Andrzej", "f12");
            //Console.Write("Done!");
            /*Console.WriteLine("Trying to login...");
            if (LibHomeBudget.Operations.UserOperations.TryLogin("Andrzej", "f121"))
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Wrong password");
            }
            Console.WriteLine("Trying to login2...");
            if (LibHomeBudget.Operations.UserOperations.TryLogin("Andrzejek", "f12"))
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Wrong password");
            }
            Console.ReadKey();*/
            //Console.WriteLine("adding settings...");
            //LibHomeBudget.InitializeDB.InitializeSettings(30, "hejo bobq", "Andrzej");
            //Console.Write("Done!");
            //TransactionOperations.AddNewTransaction(DateTime.Now, 5, TransactionOperations.GetCategoryGuid(TransactionOperations.GetCategoriesList().First()), UserOperations.GetUserGuid("Andrzej"));
            //TransactionOperations.AddNewTransaction(DateTime.Now, 45, TransactionOperations.GetCategoryGuid(TransactionOperations.GetCategoriesList().First()), UserOperations.GetUserGuid("Klaudia"));
            //TransactionOperations.AddNewTransaction(DateTime.Now.AddDays(-1), 5, TransactionOperations.GetCategoryGuid(TransactionOperations.GetCategoriesList().First()), UserOperations.GetUserGuid("Andrzej"));
            //TransactionOperations.AddNewTransaction(DateTime.Now.AddDays(-1), 45, TransactionOperations.GetCategoryGuid(TransactionOperations.GetCategoriesList().First()), UserOperations.GetUserGuid("Klaudia"));
            Console.WriteLine(TransactionOperations.GetUserTodayPayments("Andrzej").ToString());
            Console.ReadKey();
        }
    }
}
