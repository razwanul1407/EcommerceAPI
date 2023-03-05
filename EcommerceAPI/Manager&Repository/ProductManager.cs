using EcommerceAPI.Data;
using EcommerceAPI.IManager_IRepository;
using EcommerceAPI.Models;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using Microsoft.Extensions.Hosting;

namespace EcommerceAPI.Manager_Repository
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager(ProductDataContext dataContext) : base(new ProductRepository(dataContext))
        { 
        }
        public Product GetById(int id)
        {
            return GetFirstOrDefault(x => x.ProductId == id);
        }
        public ICollection<Product> GetByName(string Title)
        {
            return Get(c => c.ProductName.ToLower().Contains(Title.ToLower()));
        }
    }
}
