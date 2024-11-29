using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.EFCore;

namespace PromoCodeFactory.DataAccess.Repositories;
public class EmployeeRepository(PromoCodeDbContext context) : EfRepository<Employee>(context), IEmployeeRepository
{
}
