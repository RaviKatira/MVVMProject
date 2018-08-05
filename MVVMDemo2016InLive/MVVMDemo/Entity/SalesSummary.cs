using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SalesSummary
    {
        public string Supplier { get; set; }
        public double ProfitPerc { get; set; }
        public double SaleAmt { get; set; }
        public double CostAmt { get; set; }
        public double Profit { get; set; }
        public int QtySold { get; set; }


    }
}
