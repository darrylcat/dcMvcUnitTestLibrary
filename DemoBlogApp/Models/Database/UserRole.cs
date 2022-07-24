using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBlogApp.Models.Database
{
    public class UserRole
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required()]
        public long UserDetailId { get; set; }
        public string SiteRoleCode { get; set; }

        public UserDetail UserDetail { get; set; }
        public SiteRole SiteRole { get; set; }
    }
}
