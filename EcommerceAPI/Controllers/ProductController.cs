using EcommerceAPI.Data;
using EcommerceAPI.Manager_Repository;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductDataContext _productDataContext;

        ProductManager _productManager;

        public ProductController(ProductDataContext dataContext)
        {
            _productDataContext = dataContext;
            _productManager = new ProductManager(dataContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var prod = _productManager.GetAll().ToList();
            return Ok(prod);
        }

        [HttpGet]
        public ActionResult GetAllWithCatagory()
        {
            var product = (from prod in _productDataContext.products
                           join cata in _productDataContext.categories
                           on prod.CategoryId equals cata.CategoryId
                           select new
                           {
                               ProdId = prod.ProductId,
                               ProdName = prod.ProductName,
                               CateId = cata.CategoryId,
                               CateName = cata.CategoryName
                           }).ToList();
            return Ok(product);
        }

        [HttpGet]
        public ActionResult<Product> GetById(int id)
        {

            var prod = _productManager.GetById(id); //_productManager.GetFirstOrDefault(x => x.ProductId == id); 
            if (prod == null)
            {
                return NotFound();
            }
            return Ok(prod);
        }

        [HttpGet]
        public ActionResult<Product> GetByName(string Title)
        {
            var prod = _productManager.GetByName(Title);
            return Ok(prod);
        }

        [HttpPost]
        public ActionResult<Product> Add(Product product)
        {
            bool prod = _productManager.Add(product);
            if (prod == null)
            {
                return BadRequest("Try Again");
            }
            return Ok(prod);
        }

        [HttpPut] ///error
        public ActionResult<Product> Update(int id , Product product)
        {
            var pprod = _productManager.GetById(id);

            if (pprod == null)
            {
                return NotFound();
            }
            //if (cprod.ProductId == 0)
            //{
            //    return BadRequest("Not Found Product");
            //}
            bool prod = _productManager.Update(product);
            if (prod)
            {
                return Ok(product.ProductName);
            }
            return BadRequest("Not Update");
        }

        [HttpDelete]
        public ActionResult<Product> Delete(int id)
        {
            var prod = _productManager.GetById(id);
            if (prod == null)
            {
                return NotFound();
            }
            bool isdelete = _productManager.Delete(prod);
            if (isdelete)
            {
                return Ok("Data is Deleted");
            }
            return BadRequest("Product Is Not Delete");
        }

        //[HttpGet]

        //public List<Product> GetAllA()
        //{
        //    var product = (from prod in _productDataContext.products
        //                   join cata in _productDataContext.categories
        //                   on prod.CategoryId equals cata.CategoryId
        //                   select new Product
        //                   {
        //                       ProductId = prod.ProductId,
        //                       ProductName = prod.ProductName,
        //                       CategoryId = cata.CategoryId,
        //                      CategoryName = cata.CategoryName,
        //                   });
        //    return product.ToList();
        //}
    }
}
