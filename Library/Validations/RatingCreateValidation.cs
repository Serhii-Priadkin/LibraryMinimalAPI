using FluentValidation;
using Library.Models.DTO;

namespace Library.Validations
{
    public class RatingCreateValidation :AbstractValidator<RatingCreateDTO>
    {
        public RatingCreateValidation()
        {
            RuleFor(model => model.Score).InclusiveBetween(1, 5);
        }
    }
}
