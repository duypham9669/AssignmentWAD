using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assignment_WAD.Models
{
    public class product
    {
        public int productId { get; set; }
        public String  productName { get; set; }
        public String productDescription { get; set; }
        public String productImage { get; set; }
        public double productPrice { get; set; }
        
        public int categoryId { get; set; }
        public virtual category category { get; set; }
    }
}