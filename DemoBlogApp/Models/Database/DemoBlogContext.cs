using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoBlogApp.Models.Database
{
    public class DemoBlogContext : DbContext 
    {
        public DemoBlogContext(DbContextOptions options) : base(options) { }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<SiteRole> SiteRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
