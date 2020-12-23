using MediatR;
using AutoMapper;
using LIWEB.Domain.Util;
using LIWEB.AuthAPI.Models;
using System.Threading.Tasks;
using LIWEB.AuthAPI.Extencao;
using Microsoft.AspNetCore.Mvc;
using LIWEB.Aplicacao.Usuario.CadastroUsuario;

namespace LIWEB.AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly INotificador _notificador;
        private readonly IMediator _mediador;
        private readonly IMapper _mapper;

        public UsuarioController(INotificador notificador, IMediator mediador, IMapper mapper)
        {
            _notificador = notificador;
            _mediador = mediador;
            _mapper = mapper;
        }

        [HttpPost, Route("cadastra")]
        [ProducesResponseType(typeof(RequisicaoSucessoRespostaPadraoModel<CadastroUsuarioResponse>), 200)]
        [ProducesResponseType(typeof(RequisicaoRuimRespostaPadraoModel), 400)]
        [ProducesResponseType(typeof(ErroServidorRespostaPadraoModel), 500)]
        public async Task<IActionResult> Cadastra([FromBody] CadastroUsuarioModel model)
        {
            var request = _mapper.Map<CadastroUsuarioRequest>(model);
            return this.ObterResposta<CadastroUsuarioResponse>(_notificador, await _mediador.Send(request));
        }
    }
}
