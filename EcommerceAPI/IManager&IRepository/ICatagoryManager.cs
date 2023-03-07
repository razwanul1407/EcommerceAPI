using EcommerceAPI.Models;
using EF.Core.Repository.Interface.Manager;

namespace EcommerceAPI.IManager_IRepository
{
    public interface ICatagoryManager:ICommonManager<Catagory>
    {
        Catagory GetById(int id);
        ICollection<Catagory> GetByName(string Name);
    }
}
