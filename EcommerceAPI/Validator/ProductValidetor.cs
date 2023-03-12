using EcommerceAPI.Models;
using FluentValidation;

namespace EcommerceAPI.Validator
{
    public class ProductValidetor:AbstractValidator<Product>
    {
        public ProductValidetor()
        {
            RuleFor(p => p.ProductName).NotNull().NotEmpty()
                    .MinimumLength(5).MaximumLength(10)
                    .WithMessage("Enter Valid ProductName");

            RuleFor(p => p.CategoryId).NotNull().NotEmpty()
                .WithMessage("Enter Valid Catagory Id");
                
        }
    }
}
