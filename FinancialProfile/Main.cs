using SQLite.Net;
using System;
using UIKit;
using FinancialProfileDomain = FinancialProfile.Models.FinancialProfile;

namespace FinancialProfile
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            CreateDatabase();
            UIApplication.Main(args, null, "AppDelegate");
        }

        private static void CreateDatabase()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                System.IO.Directory.CreateDirectory(folderPath);
                string databaseFilePath = System.IO.Path.Combine(folderPath, "FinancialProfile.db");
                using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), databaseFilePath))
                {
                    db.CreateTable<FinancialProfileDomain>();
                    if (db.Table<FinancialProfileDomain>().Count() == 0)
                    {
                        var FinancialProfile = new FinancialProfileDomain()
                        {
                            Question = "When is your birthday?",
                            DataType = "DateTime"
                        };
                        db.Insert(FinancialProfile);
                        FinancialProfile = new FinancialProfileDomain()
                        {
                            Question = "What is your net worth?",
                            DataType = "Int"
                        };
                        db.Insert(FinancialProfile);
                        FinancialProfile = new FinancialProfileDomain()
                        {
                            Question = "How much do you make each month after taxes including 1099, w2, 401k, and ira contributions?",
                            DataType = "Int"
                        };
                        db.Insert(FinancialProfile);
                        FinancialProfile = new FinancialProfileDomain()
                        {
                            Question = "How much do you spend each month on your house?",
                            DataType = "Int"
                        };
                        db.Insert(FinancialProfile);
                        FinancialProfile = new FinancialProfileDomain()
                        {
                            Question = "How much do you spend each month on your car?",
                            DataType = "Int"
                        };
                        db.Insert(FinancialProfile);
                        FinancialProfile = new FinancialProfileDomain()
                        {
                            Question = "How much do you spend each month on everything else?",
                            DataType = "Int"
                        };
                        db.Insert(FinancialProfile);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                var t = ex;
            }
        }
    }
}