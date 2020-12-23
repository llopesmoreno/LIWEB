using FluentValidation;
using LIWEB.Domain.Entidades;

namespace LIWEB.Domain.Validadores
{
    public class UsuarioValidador : AbstractValidator<Usuario>
    {
        public UsuarioValidador()
        {
            RuleFor(usuario => usuario.Nome).EmailAddress().WithMessage("Nome inválido");
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage("E-mail inválido");
            RuleFor(usuario => usuario.Senha).EmailAddress().WithMessage("Senha inválida");
        }
    }
}
