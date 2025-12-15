using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Haushaltsbuch.Model;
using Haushaltsbuch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Haushaltsbuch.ViewModel
{
    public partial class NewTransactionViewModel : ObservableObject
    {

        private CategoryService _categoryService;
        private TransactionService _transactionService;

        public ICommand NewTransactionCommand { get; }

        public ObservableCollection<Category> Categories { get; set; }
        
        [ObservableProperty]
        public Category selectedCategory;

        [ObservableProperty]
        public string newTransactionAmount;

        [ObservableProperty]
        public TransactionType transactionType;

        public NewTransactionViewModel(CategoryService categoryService, TransactionService transactionService)
        {
            _categoryService = categoryService;
            _transactionService = transactionService;

            NewTransactionCommand = new RelayCommand(NewTransaction);
            Categories = _categoryService.GetCategories();
            SelectedCategory = Categories.First();
            NewTransactionAmount = "100";
            TransactionType = TransactionType.Expense;
        }

        public void NewTransaction()
        {
            try
            {
                decimal amount = decimal.Parse(NewTransactionAmount);
                _transactionService.NewTransaction(amount, SelectedCategory, DateTime.Now, TransactionType);
            }
            catch { }
        }
    }
}
