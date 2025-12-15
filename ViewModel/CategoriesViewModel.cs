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
    class CategoriesViewModel : ObservableObject
    {
        private TransactionService _transactionService;

        public ObservableCollection<Transaction> Transactions { get; set; }
        public IEnumerable<CategoryTransactionRelation> CategorySummary => GetCategorySummary();

        public CategoriesViewModel(TransactionService transactionService)
        {
            _transactionService = transactionService;
            Transactions = _transactionService.GetTransactions();

            Transactions.CollectionChanged += OnAllTransactionsChanged;
        }

        private IEnumerable<CategoryTransactionRelation> GetCategorySummary()
        {
            return Transactions
                .Where(t => t.Date.Month == DateTime.Now.Month)
                .GroupBy(t => t.Category.Name)
                .Select(g => new CategoryTransactionRelation
                {
                    CategoryName = g.Key,
                    TotalAmount = g.Sum(t => t.Type == TransactionType.Income
                        ? t.Amount
                        : -t.Amount)
                });
        }

        private void OnAllTransactionsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CategorySummary));
        }
    }
}
