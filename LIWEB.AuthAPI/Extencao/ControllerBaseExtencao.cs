using LIWEB.Domain.Util;
using LIWEB.AuthAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LIWEB.AuthAPI.Extencao
{
    public static class ControllerBaseExtencao
    {
        public static ActionResult ObterResposta<T>(this ControllerBase controller, INotificador notificador, object response = null)
        {
            if (notificador.TemNotificacao())
                return controller.BadRequest(new RequisicaoRuimRespostaPadraoModel(notificador.ObterMensagensNotificacoes()));

            return controller.Ok(new RequisicaoSucessoRespostaPadraoModel<T>(CoverterObjeto<T>(response)));
        }

        private static I CoverterObjeto<I>(object response)
        {
            if (response is I)
            {
                return (I)response;
            }

            try
            {
                return (I)System.Convert.ChangeType(response, typeof(I));
            }
            catch (System.InvalidCastException)
            {
                throw;
            }
        }

    }
}
