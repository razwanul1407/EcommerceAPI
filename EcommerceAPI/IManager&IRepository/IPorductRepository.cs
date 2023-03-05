using EcommerceAPI.Models;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Repository;

namespace EcommerceAPI.IManager_IRepository
{
    public interface IPorductRepository:ICommonRepository<Product>
    {
    }
}
