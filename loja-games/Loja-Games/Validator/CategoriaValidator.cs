using FluentValidation;
using Loja_Games.Model;

namespace Loja_Games.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(p => p.Tipo)
                    .NotEmpty();
        }
    }
}
