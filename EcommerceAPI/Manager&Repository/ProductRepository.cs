using EcommerceAPI.Data;
using EcommerceAPI.IManager_IRepository;
using EcommerceAPI.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Manager_Repository
{
    public class ProductRepository : CommonRepository<Product>, IPorductRepository
    {
        public ProductRepository(ProductDataContext dbContext) : base(dbContext)
        {
        }

        //public List<Product> GetAll()
        //{
        //    var products = (from prod in dbContext.Products
        //                    join cate in _context.Categories
        //                    on prod.CatagoryId equals cate.CId
        //                    select new Product
        //                    {
        //                        PId = prod.PId,
        //                        PName = prod.PName,
        //                        CatagoryId = prod.CatagoryId,
        //                        CatagoryName = cate.CName,

        //                    });
        //    return products.ToList();
        //}
    }
}
