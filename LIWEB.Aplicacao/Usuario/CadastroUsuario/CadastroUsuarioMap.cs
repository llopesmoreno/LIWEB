using AutoMapper;
using EntidadeUsuario = LIWEB.Domain.Entidades.Usuario;

namespace LIWEB.Aplicacao.Usuario.CadastroUsuario
{
    public class CadastroUsuarioMap : Profile
    {
        public CadastroUsuarioMap()
        {
            CreateMap<CadastroUsuario, EntidadeUsuario>();
            CreateMap<EntidadeUsuario, CadastroUsuarioResponse>()
                .ForMember(dest => dest.Usuario, orign => orign.MapFrom(o => o));
        }
    }
}