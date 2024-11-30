using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.EFCore;

namespace PromoCodeFactory.DataAccess.Repositories;
public class CustomerRepository(PromoCodeDbContext context) : EfRepository<Customer>(context), ICustomerRepository
{
}
