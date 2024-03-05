using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSupermarket.MODEL
{
    public class ProductLine
    {
        public string productLine { get; set; }
        public string TextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}