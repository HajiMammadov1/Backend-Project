using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
