using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.EFCore;

namespace PromoCodeFactory.DataAccess.Repositories;
public class RoleRepository(PromoCodeDbContext context) : EfRepository<Role>(context), IRoleRepository
{
}
