using FluentValidation;
using Library.Models.DTO;

namespace Library.Validations
{
    public class BookCreateValidation: AbstractValidator<BookCreateDTO>
    {
        public BookCreateValidation()
        {

        }
    }
}
