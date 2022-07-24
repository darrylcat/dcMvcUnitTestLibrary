using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBlogApp.Models.Database
{
    public class SiteRole
    {
        [Key()]
        [MaxLength(10)]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
