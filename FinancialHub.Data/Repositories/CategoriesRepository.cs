using FinancialHub.Data.Contexts;
using FinancialHub.Domain.Entities;
using FinancialHub.Domain.Interfaces.Repositories;

namespace FinancialHub.Data.Repositories
{
    public class CategoriesRepository : BaseRepository<CategoryEntity>, ICategoriesRepository
    {
        public CategoriesRepository(FinancialHubContext context) : base(context)
        {
        }
    }
}
