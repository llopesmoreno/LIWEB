using System.Linq;
using FluentValidation;
using LIWEB.Domain.Entidades;
using System.Collections.Generic;

namespace LIWEB.Domain.Util
{
    public static class ValidadorHelper 
    {
        public static bool EntidadeInvalida<T>(this IEnumerable<T> entidades, IValidator<T> validator, INotificador notificador)
        {
            foreach (var item in entidades)
            {
                var resultadoValidacao = validator.Validate(item);

                if (!resultadoValidacao.IsValid)
                {
                    var mensagensErro = resultadoValidacao.Errors.Select(e => e.ErrorMessage);
                    notificador.Adicionar(mensagensErro);
                }
            }

            return notificador.TemNotificacao();
        }

        public static bool EntidadeInvalida<T>(this T entidade, IValidator<T> validator, INotificador notificador)
        {
            var validacoesResultado = validator.Validate(entidade);

            if (!validacoesResultado.IsValid)
                notificador.Adicionar(validacoesResultado.Errors);

            return notificador.TemNotificacao();
        }
    }
}
