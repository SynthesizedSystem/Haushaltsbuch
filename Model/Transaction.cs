using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Model
{
    public enum TransactionType
    {
        Income,
        Expense
    }

    public class Transaction
    {
        public required decimal Amount { get; set; }
        public required Category Category { get; set; }
        public required DateTime Date { get; set; }
        public required TransactionType Type { get; set; }


        public string FormattedAmount => String.Format("{0}{1:N2} €", Type == TransactionType.Income ? "+" : "-", Amount);
    }
}
