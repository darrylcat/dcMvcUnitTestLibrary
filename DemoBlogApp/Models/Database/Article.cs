using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBlogApp.Models.Database
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string KeyWords { get; set; }
        public DateTime Created { get; set; }
        public long UserDetailsId { get; set; }
        public UserDetail UserDetail { get; set; }
        public DateTime? Published { get; set; }

    }
}
