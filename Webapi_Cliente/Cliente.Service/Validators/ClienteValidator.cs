using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi_Cliente.Domain.Entities;

namespace Webapi_Cliente.Service.Validators
{
    public class ClienteValidator: AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Objeto não encontrado.");
                    });

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("É necessário informar o Cep.")
                .NotNull().WithMessage("É necessário informar o Cep.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("É necessário informar o E-mail.")
                .NotNull().WithMessage("É necessário informar o E-mail.");

        }

    }
}
