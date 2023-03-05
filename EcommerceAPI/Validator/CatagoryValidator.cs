using EcommerceAPI.Models;
using FluentValidation;

namespace EcommerceAPI.Validator
{
    public class CatagoryValidator:AbstractValidator<Catagory>
    {
        public CatagoryValidator()
        {
            RuleFor(c => c.CategoryName).NotNull().NotEmpty()
                .WithMessage("Enter Valid Name")
                .MinimumLength(5).MaximumLength(10);
        }
    }
}
