
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using timeCamp.CommonLogic.Modal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace timeCamp.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {

        private readonly IConfiguration Configuration;

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<EmployeeCredentials> EmployeeCredentials { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Address>().HasKey(a => a.Id);
            builder.Entity<Employee>().HasKey(a => a.Id);
            builder.Entity<Job>().HasKey(a => a.Id);
            builder.Entity<Ticket>().HasKey(a => a.Id);
            builder.Entity<EmployeeCredentials>().HasKey(a => a.Id);


            // Configure Employee-EmployeeCredentials one-to-one relationship
            builder.Entity<Employee>()
                .HasOne(e => e.EmployeeCredentials)
                .WithOne(ec => ec.Employee)
                .HasForeignKey<EmployeeCredentials>(ec => ec.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // O

            //builder.Entity<Employee>()
            //    .HasMany(e => e.Tickets)
            //    .WithOne(t => t.Employee)
            //    .HasForeignKey(t => t.EmployeeId)
            //    .OnDelete(DeleteBehavior.Cascade);


            //builder.Entity<Employee>()
            //   .HasOne(e => e.Address)
            //   .WithOne(a => a.Employee)
            //   .HasForeignKey<Address>(a => a.EmployeeId)
            //   .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Employee>()
            //    .HasOne(e => e.Job)                    // One Employee has one Job
            //    .WithOne(j => j.Employee)               // One Job belongs to one Employee
            //    .HasForeignKey<Job>(j => j.EmployeeId)  // Foreign key is Job.EmployeeId
            //    .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(builder);
        }

    }
}
