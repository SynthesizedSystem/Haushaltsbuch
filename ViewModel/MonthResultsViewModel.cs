using CommunityToolkit.Mvvm.ComponentModel;
using Haushaltsbuch.Model;
using Haushaltsbuch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.ViewModel
{
    class MonthResultsViewModel : ObservableObject
    {
        public string CurrentMonth => String.Format("Monatsübersicht {0}", DateTime.Now.ToString("MMMM", new CultureInfo("de-DE")));
        public string MonthlyExpenses => String.Format("{0:N2} €", GetMonthlyExpenses());
        public string MonthlyIncomes => String.Format("{0:N2} €", GetMonthlyIncomes());
        public string MonthlyDifference => String.Format("{0:N2} €", GetMontlyDifference());
        public string MonthlyDifferencePercentage => String.Format("({0:N2}% gespart)", GetMonthlyDifferencePercentage());

        private TransactionService _transactionService;
        public MonthResultsViewModel(TransactionService transactionService)
        {
            _transactionService = transactionService;
            ObservableCollection<Transaction> transactions = _transactionService.GetTransactions();
            transactions.CollectionChanged += OnAllTransactionsChanged;
        }

        private void OnAllTransactionsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CurrentMonth));
            OnPropertyChanged(nameof(MonthlyExpenses));
            OnPropertyChanged(nameof(MonthlyIncomes));
            OnPropertyChanged(nameof(MonthlyDifference));
            OnPropertyChanged(nameof(MonthlyDifferencePercentage));
        }

        private decimal GetMonthlyExpenses()
        {
            return _transactionService
                .GetTransactions()
                .Where(t =>
                    t.Type == TransactionType.Expense &&
                    t.Date.Month == DateTime.Now.Month)
                .Sum(t => t.Amount);
        }

        private decimal GetMonthlyIncomes()
        {
            return _transactionService
                .GetTransactions()
                .Where(t => 
                    t.Type == TransactionType.Income &&
                    t.Date.Month == DateTime.Now.Month)
                .Sum(t => t.Amount);
        }

        private decimal GetMontlyDifference()
        {
            return GetMonthlyIncomes() - GetMonthlyExpenses();
        }

        private decimal GetMonthlyDifferencePercentage()
        {
            if (GetMonthlyIncomes() != 0)
                return GetMontlyDifference() / GetMonthlyIncomes() * 100;
            return 0;
        }
    }
}
