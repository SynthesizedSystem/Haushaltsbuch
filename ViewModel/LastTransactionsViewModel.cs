using CommunityToolkit.Mvvm.ComponentModel;
using Haushaltsbuch.Model;
using Haushaltsbuch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.ViewModel
{
    public class LastTransactionsViewModel : ObservableObject
    {
        private TransactionService _transactionService;
        public ObservableCollection<Transaction> Transactions { get; set; }
        public IEnumerable<Transaction> LastTransactions => Transactions.Reverse().Take(5);
        public LastTransactionsViewModel(TransactionService transactionService)
        {
            _transactionService = transactionService;
            Transactions = _transactionService.GetTransactions();
            Transactions.CollectionChanged += OnAllTransactionsChanged;
        }

        private void OnAllTransactionsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LastTransactions));
        }
    }
}
