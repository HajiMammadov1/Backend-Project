using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Models
{
    public class Color:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }
        public List<ProductColor> ProductColors { get; set; }

    }
}
