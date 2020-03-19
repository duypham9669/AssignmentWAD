namespace assignment_WAD.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=productContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<assignment_WAD.Models.product> products { get; set; }

        public System.Data.Entity.DbSet<assignment_WAD.Models.category> categories { get; set; }
    }
}
