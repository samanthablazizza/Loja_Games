namespace Loja_Games.Validator;
    using FluentValidation;
using Loja_Games.Model;

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {

        RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

        RuleFor(p => p.Descricao)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(1000);
    }
}

