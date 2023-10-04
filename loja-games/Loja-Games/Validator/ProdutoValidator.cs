﻿namespace Loja_Games.Validator;
    using FluentValidation;
using Loja_Games.Model;

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {

        RuleFor(p => p.Nome)
                .NotEmpty();

        RuleFor(p => p.Descricao)
                .NotEmpty();

        RuleFor(p => p.Console)
                .NotEmpty();

        RuleFor(p => p.Preco)
            .NotNull()
            .GreaterThan(0)
            .PrecisionScale(20, 2, false);;

    }
}

