using FluentValidation;
using Loja_Games.Model;

namespace Loja_Games.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {

            RuleFor(t => t.Tipo)
                    .NotEmpty()
                    .MaximumLength(255);
        }
    }
}
