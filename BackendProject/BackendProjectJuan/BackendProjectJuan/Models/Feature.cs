using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        [StringLength(maximumLength: 20)]
        public string Title { get; set; }
        [StringLength(maximumLength: 20)]
        public string Desc { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
