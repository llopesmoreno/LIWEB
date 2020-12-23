using AutoMapper;
using LIWEB.AuthAPI.Models;
using LIWEB.Aplicacao.Usuario.CadastroUsuario;

namespace LIWEB.AuthAPI.Mapeamento
{
    public class CadastroUsuarioMapeamento : Profile
    {
        public CadastroUsuarioMapeamento()
        {
            CreateMap<CadastroUsuarioModel, CadastroUsuarioRequest>();                
        }
    }
}
