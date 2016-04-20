using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using FinancialProfileDomain = FinancialProfile.Models.FinancialProfile;

namespace FinancialProfile.Repositories
{
    public class FinancialProfileRepository
    {
        private SQLiteConnection db;
        public FinancialProfileRepository()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            System.IO.Directory.CreateDirectory(folderPath);
            string databaseFilePath = System.IO.Path.Combine(folderPath, "FinancialProfile.db");
            db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS(), databaseFilePath);
        }

        public FinancialProfileDomain Get(int Id)
        {
            return db.Find<FinancialProfileDomain>(Id);
        }

        public FinancialProfileDomain Update(FinancialProfileDomain item)
        {
            db.Update(item);
            return Get(item.Id);
        }
    }
}
