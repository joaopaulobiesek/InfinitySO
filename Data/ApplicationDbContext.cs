using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsEmployee;
using InfinitySO.Models.ModelsPatrimony;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.ModelsSystem;
using InfinitySO.Models.ModelsUserDataLogin;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfinitySO.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> //IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //Start Administration
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<MainBoard> MainBoard { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<SupplyAdd> SupplyAdd { get; set; }
        public DbSet<WithdrawalSupply> WithdrawalSupply { get; set; }
        //End Administration

        //Start Employee
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Scale> Scale { get; set; }
        public DbSet<TimePoint> TimePoint { get; set; }
        //End Employee

        //Start Patrimony
        public DbSet<HistoricPatrimony> HistoricPatrimony { get; set; }
        public DbSet<Patrimony> Patrimony { get; set; }
        public DbSet<Product> Product { get; set; }
        //End Patrimony

        //Start System
        public DbSet<DownloadFile> DownloadFile { get; set; }
        public DbSet<SystemController> SystemController { get; set; }
        public DbSet<SystemSubController> SystemSubController { get; set; }
        //End System

        //Start Student
        public DbSet<BilletValue> BilletValue { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentFinancial> StudentFinancial { get; set; }
        //End Student

        //Start UserDataLogin
        public DbSet<UserDataLogin> UserDataLogin { get; set; }
        //End UserDataLogin
    }
}