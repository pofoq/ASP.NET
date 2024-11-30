using PromoCodeFactory.DataAccess.EFCore;

namespace PromoCodeFactory.DataAccess.Data;
public static class DbInitializer 
{
    public static void Initialize(PromoCodeDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Employees.AddRange(FakeDataFactory.Employees);
        context.Preferences.AddRange(FakeDataFactory.Preferences);
        context.Customers.AddRange(FakeDataFactory.Customers);
    }
}
