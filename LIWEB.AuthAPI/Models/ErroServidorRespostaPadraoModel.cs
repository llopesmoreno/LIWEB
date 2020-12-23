using System;
using System.Collections.Generic;

namespace LIWEB.AuthAPI.Models
{
    public class ErroServidorRespostaPadraoModel
    {
        public ErroServidorRespostaPadraoModel()
        {
            Valido = false;
            Protocolo = Guid.NewGuid();
            Mensagens = new List<string>() { "Ops... Uma falha ocorreu!" };
        }

        public bool Valido { get; private set; }
        public List<string> Mensagens { get; private set; }
        public Guid Protocolo { get; private set; }
    }
}
