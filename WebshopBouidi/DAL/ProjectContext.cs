using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebshopBouidi.Models;

namespace WebshopBouidi.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base(ConfigurationManager.ConnectionStrings["connection"].ConnectionString)
        {
        }

        public DbSet<AppointmentModel> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.HasDefaultSchema("dbo");
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}