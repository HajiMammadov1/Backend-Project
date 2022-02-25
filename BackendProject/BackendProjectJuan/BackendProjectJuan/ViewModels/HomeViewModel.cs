using BackendProjectJuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Feature> Features { get; set; }
        public List<Setting> Settings { get; set; }
        public List<Product> Products { get; set; }
        public List<PromotionBrand> PromotionBrands { get; set; }
        public List<Product> TopSeller { get; set; }
    }
}
