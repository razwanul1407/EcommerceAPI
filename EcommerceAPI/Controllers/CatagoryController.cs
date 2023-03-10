using EcommerceAPI.Data;
using EcommerceAPI.Manager_Repository;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data;
using System.Linq; 

namespace EcommerceAPI.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        ProductDataContext _productDataContext;

        CatagoryManager _catagoryManager;

        public CatagoryController(ProductDataContext dataContext)
        {
            _productDataContext = dataContext;
            _catagoryManager = new CatagoryManager(dataContext);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var cata = _catagoryManager.GetAll().ToList();
            return Ok(cata);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllWithProduct()
        {
        
            //var catagory = (from cata in _productDataContext.categories
            //                join prod in _productDataContext.products
            //                on cata.CategoryId equals prod.CategoryId
            //                select new AllC
            //                {
            //                    CateId = cata.CategoryId,
            //                    CateName = cata.CategoryName,
            //                    ProdProduct = cata.Products.ToList(),
            //                });

            var categroy= (from cata in _productDataContext.categories
                          join prod in _productDataContext.products
                          on cata.CategoryId equals prod.CategoryId 
                          into GroupJoin select new 
                          {
                              CategroyId = cata.CategoryId,
                              CateName = cata.CategoryName,
                              ProdProduct = cata.Products
                          }).ToList();
            
            // var catagory = _productDataContext.categories.Select(x => x.Products).ToList();
            return Ok(categroy);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<Catagory> GetById(int id)
        {
            var prod = _catagoryManager.GetById(id); //_catagoryManager.GetFirstOrDefault(x => x.ProductId == id); 
            if (prod == null)
            {
                return NotFound();
            }
            return Ok(prod);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<Catagory> GetByName(string Name)
        {
            var prod = _catagoryManager.GetByName(Name);
            return Ok(prod);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Catagory> Add(Catagory category)
        {
            bool cata = _catagoryManager.Add(category);
            if (cata == null)
            {
                return BadRequest("Try Again");
            }
            return Ok(cata);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public ActionResult<Catagory> Update(Catagory catagory)
        {
            if (catagory.CategoryId == 0)
            {
                return BadRequest("Not Found Product");
            }
            bool prod = _catagoryManager.Update(catagory);
            if (prod)
            {
                return Ok(catagory);
            }
            return BadRequest("Not Update");
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete]
        public ActionResult<Catagory> Delete(int id)
        {
            var cate = _catagoryManager.GetById(id);
            if (cate == null)
            {
                return NotFound();
            }
            bool isdelete = _catagoryManager.Delete(cate);
            if (isdelete)
            {
                return Ok("Catagory Is Deleted");
            }
            return BadRequest("Catagory Is Not Deleted");
        }
    }
}
