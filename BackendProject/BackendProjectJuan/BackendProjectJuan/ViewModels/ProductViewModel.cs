using BackendProjectJuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.ViewModels
{
    public class ProductViewModel
    {

        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Color> Colors { get; set; }
        public List<Category> Categories { get; set; }
        public List<Setting> Settings { get; set; }

    }
}
