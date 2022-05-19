using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes.App.Models
{
    public class JsonProduct
    {
        public string code { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string imported { get; set; }
        public int quantity { get; set; }
    }
}
