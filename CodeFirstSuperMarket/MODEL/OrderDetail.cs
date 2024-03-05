using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSupermarket.MODEL
{
    public class OrderDetail
    {
        public int OrderNumber { get; set; }
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public int OrderLineNumber { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}