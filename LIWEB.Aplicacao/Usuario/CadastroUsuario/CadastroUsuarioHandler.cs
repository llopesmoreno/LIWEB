using System;
using MediatR;
using AutoMapper;
using System.Threading;
using LIWEB.Domain.Util;
using System.Threading.Tasks;
using LIWEB.Domain.Repositorios;

namespace LIWEB.Aplicacao.Usuario.CadastroUsuario
{
    public class CadastroUsuarioHandler : IRequestHandler<CadastroUsuarioRequest, CadastroUsuarioResponse>
    {
        private readonly INotificador _notificador;
        private readonly IUsuarioRepositorio _repositorioUsuario;
        private readonly IMapper _mapper;

        public CadastroUsuarioHandler(INotificador notificador, IUsuarioRepositorio repositorioUsuario, IMapper mapper)
        {
            _notificador = notificador;
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
        }

        public Task<CadastroUsuarioResponse> Handle(CadastroUsuarioRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("não implementado");
        }
    }
}
