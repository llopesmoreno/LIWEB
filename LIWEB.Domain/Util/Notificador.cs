using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace LIWEB.Domain.Util
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        List<string> ObterMensagensNotificacoes();
        void Adicionar(string mensagem);
        void Adicionar(IEnumerable<string> mensagens);
        void Adicionar(IEnumerable<ValidationFailure> validationFailures);
        void ExcluirNotificacoes();
    }

    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }

    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes = new List<Notificacao>();

        public void Adicionar(string mensagem)
        {
            _notificacoes.Add(new Notificacao(mensagem));
        }

        public void Adicionar(IEnumerable<string> mensagems)
        {
            var mensagens = mensagems.Select(mensagem => new Notificacao(mensagem));

            _notificacoes.AddRange(mensagens);
        }

        public void Adicionar(IEnumerable<ValidationFailure> validationFailures)
        {
            var mensagens = validationFailures.Select(v => v.ErrorMessage);
            var objetos = mensagens.Select(m => new Notificacao(m));
            _notificacoes.AddRange(objetos);
        }

        public void ExcluirNotificacoes() => _notificacoes = new List<Notificacao>();

        public List<string> ObterMensagensNotificacoes()
        {
            return _notificacoes.Select(n => n.Mensagem).ToList();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}