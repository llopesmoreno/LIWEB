using System.Collections.Generic;

namespace LIWEB.AuthAPI.Models
{
    public class RequisicaoRuimRespostaPadraoModel
    {
        public RequisicaoRuimRespostaPadraoModel(List<string> mensagens)
        {
            Mensagens = mensagens;
            Valido = false;
        }

        public bool Valido { get; private set; }
        public List<string> Mensagens { get; private set; }
    }
}
