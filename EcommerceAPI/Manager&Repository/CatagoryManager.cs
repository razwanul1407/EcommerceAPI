﻿using EcommerceAPI.Data;
using EcommerceAPI.IManager_IRepository;
using EcommerceAPI.Models;
using EF.Core.Repository.Interface.Manager;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace EcommerceAPI.Manager_Repository
{
    public class CatagoryManager : CommonManager<Catagory>, ICatagoryManager
    {
        public CatagoryManager(ProductDataContext dataContext) : base(new CatagoryRepository(dataContext))
        {
        }
        public Catagory GetById(int id)
        {
            return GetFirstOrDefault(x => x.CategoryId == id);
        }
        public List<Catagory> GetByName(string Name)
        {
            return (List<Catagory>)Get(c => c.CategoryName.ToLower() == Name.ToLower());
        }
    }
}