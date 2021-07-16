using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobCrudXamarin.Models
{
    public class Company
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }

        public override string ToString()
        {
            return this.Title +" --- " +"( Amount Spent: " + $"{String.Format("{0:#,###,###.##}", this.Amount)}" +")";
        }
    }
}
