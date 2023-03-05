using EcommerceAPI.Models;
using EF.Core.Repository.Interface.Manager;

namespace EcommerceAPI.IManager_IRepository
{
    public interface IProductManager:ICommonManager<Product>
    {
        Product GetById(int id);
        ICollection<Product> GetByName(string title);
    }
}
