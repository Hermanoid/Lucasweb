using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lucasweb.DatabaseAccessors.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=LucaswebContext")
        {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
