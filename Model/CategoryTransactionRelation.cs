using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Model
{
    class CategoryTransactionRelation
    {
        public string CategoryName { get; set; } = "";
        public decimal TotalAmount { get; set; }
        public string FormattedTotal => String.Format("{0:N2} €", TotalAmount);
    }
}
