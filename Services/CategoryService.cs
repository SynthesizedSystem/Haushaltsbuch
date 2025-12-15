using Haushaltsbuch.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Services
{
    public class CategoryService
    {
        private ObservableCollection<Category> _categories;

        public CategoryService()
        {
            _categories = new ObservableCollection<Category>() {
                new Category { Name = "💵 Gehalt"},
                new Category { Name = "🛒 Lebensmittel"},
                new Category { Name = "🏠 Miete" },
                new Category { Name = "🚗 Verkehr" },
                new Category { Name = "🎬 Freizeit" },
                new Category { Name = "📦 Sonstiges" }
            };
        }

        public ObservableCollection<Category> GetCategories()
        {
            return _categories;
        }

        public void AddCategory(string categoryName)
        {
            _categories.Add(new Category() { Name = categoryName });
        }

        public void RemoveCategory(string categoryName)
        {
            _categories.Remove(new Category() { Name = categoryName });
        }
    }
}
