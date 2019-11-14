using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data_Access_Layer
{

    public class SolutionAcceleratorContext : DbContext
    {
        // Your context has been configured to use a 'SolutionAcceleratorContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SolutionAccelerator.Data_Access_Layer.SolutionAcceleratorContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SolutionAcceleratorContext' 
        // connection string in the application configuration file.
        public SolutionAcceleratorContext()
            : base("name=SolutionAcceleratorContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Course> Cources { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Packet> Packets { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<PacketPrice> PacketPrices { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

}