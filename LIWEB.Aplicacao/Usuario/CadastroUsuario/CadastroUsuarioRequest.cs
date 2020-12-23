using MediatR;

namespace LIWEB.Aplicacao.Usuario.CadastroUsuario
{
    public class CadastroUsuarioRequest : IRequest<CadastroUsuarioResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}