using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class Catagory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products;
    }
}