using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assignment_WAD.Models
{
    public class category
    {
        public int categoryId { get; set; }
        public String  categoryName { get; set; }
        public virtual ICollection<product> Products { get; set; }
    }
}