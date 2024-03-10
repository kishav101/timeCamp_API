
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

            builder.Entity<Employee>().HasOne(a => a.Address);
            builder.Entity<Employee>().HasOne(a => a.Job);
            builder.Entity<Employee>().HasMany(a => a.Tickets);
            builder.Entity<Employee>().HasOne(a => a.EmployeeCredentials);

            base.OnModelCreating(builder);
        }

    }
}
