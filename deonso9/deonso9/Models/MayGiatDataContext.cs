using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace deonso9.Models
{
    public partial class MayGiatDataContext : DbContext
    {
        public MayGiatDataContext()
            : base("name=MayGiatDataContext")
        {
        }
        public DbSet<MayGiat> MayGiats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
