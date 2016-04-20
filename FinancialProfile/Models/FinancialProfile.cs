using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialProfile.Models
{
    public class FinancialProfile
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string DataType { get; set; }
    }
}
