using Haushaltsbuch.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Services
{
    public class TransactionService
    {
        private ObservableCollection<Transaction> _transactions;

        public TransactionService()
        {
            _transactions = new ObservableCollection<Transaction>();
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public void NewTransaction(decimal amount, Category category, DateTime date, TransactionType transactionType)
        {
            _transactions.Add(new Transaction { Amount = amount, Category = category, Date = date, Type = transactionType });
        }
    }
}
