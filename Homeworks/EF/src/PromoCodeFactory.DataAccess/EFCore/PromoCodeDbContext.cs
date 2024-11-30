using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Data;
using System;

namespace PromoCodeFactory.DataAccess.EFCore;
public class PromoCodeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }
    public DbSet<CustomerPreference> CustomerPreferences { get; set; }

    public PromoCodeDbContext(DbContextOptions<PromoCodeDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>(role =>
        {
            role
                .Property(r => r.Name)
                .HasMaxLength(150);
            role
                .Property(r => r.Description)
                .HasMaxLength(150);
            role
                .HasData(FakeDataFactory.Roles);
        });

        modelBuilder.Entity<Employee>(employee =>
        {
            employee
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId);
            employee
                .HasData(FakeDataFactory.Employees);
            employee
                .Property(c => c.FirstName)
                .HasMaxLength(150);
            employee
                .Property(c => c.LastName)
                .HasMaxLength(150);
            employee
                .Property(c => c.Email)
                .HasMaxLength(150);
        });

        modelBuilder.Entity<Customer>(customer =>
        {
            customer
                .HasMany(c => c.PromoCodes)
                .WithOne(p => p.Customer);
            customer
                .Property(c => c.FirstName)
                .HasMaxLength(150);
            customer
                .Property(c => c.LastName)
                .HasMaxLength(150);
            customer
                .Property(c => c.Email)
                .HasMaxLength(150);
            customer
                .HasData(FakeDataFactory.Customers);
        });

        modelBuilder.Entity<PromoCode>(promoCode =>
        {
            promoCode
                .Property(p => p.Code)
                .HasMaxLength(150);
            promoCode
                .Property(p => p.ServiceInfo)
                .HasMaxLength(150);
            promoCode
                .Property(p => p.PartnerName)
                .HasMaxLength(150);
        });

        modelBuilder.Entity<PromoCode>()
            .HasOne(p => p.Preference);

        modelBuilder.Entity<Preference>(preference =>
        {
            preference
                .Property(p => p.Name)
                .HasMaxLength(150);
            preference
                .HasData(FakeDataFactory.Preferences);
        });

        modelBuilder.Entity<CustomerPreference>(customerPreference =>
        {
            customerPreference
                .HasKey(cp => new { cp.CustomerId, cp.PreferenceId });
            //customerPreference
            //    .HasOne(cp => cp.Customer)
            //    .WithMany(c => c.CustomerPreferences)
            //    .HasForeignKey(cp => cp.CustomerId);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }
}
