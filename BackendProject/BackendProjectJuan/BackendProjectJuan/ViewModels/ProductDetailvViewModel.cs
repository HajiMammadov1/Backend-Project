using BackendProjectJuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.ViewModels
{
    public class ProductDetailvViewModel
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public ProductComment Comment { get; set; }
    }
}
