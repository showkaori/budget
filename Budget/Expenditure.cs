using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget
{
    internal class Expenditure
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public string Memo { get; set; }
        public string Category { get; set; }
        public int Money { get; set; }
        public string Payment { get; set; }
        public DateTime Day { get; set; }
        public string Month { get; set; }

        public Expenditure(int id, string detail, string memo, string category, int money, string payment, DateTime day, string month)
        {
            Id = id;
            Detail = detail;
            Memo = memo;
            Category = category;
            Money = money;
            Payment = payment;
            Day = day;
            Month = month;
        }

        public string StrDay()
        {
            var Day1 = Day.ToString("MM月dd日");

            return Day1;
        }
    }
}
