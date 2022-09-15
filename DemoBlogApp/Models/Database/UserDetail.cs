using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBlogApp.Models.Database
{
    public class UserDetail
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(10)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
    }
}
