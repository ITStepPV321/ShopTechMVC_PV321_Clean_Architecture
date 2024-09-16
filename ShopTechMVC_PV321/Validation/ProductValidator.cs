using DataAccess.Entities;
using FluentValidation;

namespace ShopTechMVC_PV321.Validation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product=>product.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Value {PropertyValue} is incorrect. {PropertyName} is required and must be len greater 2!!!" );


            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Value {PropertyValue} of property {PropertyName} is incorrect.");

            RuleFor(product => product.ImagePath)
                .Must(LinkMustBeUrl)
                .WithMessage("{PropertyName} has incorrect URL format");
            }

        private static bool LinkMustBeUrl(string link) {
            if (string.IsNullOrWhiteSpace(link))
                return false;

            Uri resultUri;
            return Uri.TryCreate(link, UriKind.Absolute, out resultUri);
        }
    }
}
