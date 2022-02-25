using BackendProjectJuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.ViewModels
{
    public class CheckoutViewModel
    {
        public BasketViewModel Basket { get; set; }
        public Order Order { get; set; }
    }
}
