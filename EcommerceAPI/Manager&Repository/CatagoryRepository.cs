using EcommerceAPI.Data;
using EcommerceAPI.IManager_IRepository;
using EcommerceAPI.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Manager_Repository
{
    public class CatagoryRepository : CommonRepository<Catagory>, ICatagoryRepository
    {
        public CatagoryRepository(ProductDataContext dbContext) : base(dbContext)
        {
        }
    }
}
