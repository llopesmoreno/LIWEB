using System;

namespace LIWEB.Domain.Entidades
{
    public class Usuario //: Entidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }        
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}