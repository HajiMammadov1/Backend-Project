﻿using BackendProjectJuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.ViewModels
{
    public class ProductBasketItemViewModel
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
