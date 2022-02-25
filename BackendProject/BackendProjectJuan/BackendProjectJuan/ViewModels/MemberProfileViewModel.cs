using BackendProjectJuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.ViewModels
{
    public class MemberProfileViewModel
    {
        public MemberProfileUpdateViewModel Member { get; set; }
        public List<Order> Orders { get; set; }
    }
}
