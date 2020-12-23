namespace LIWEB.AuthAPI.Models
{
    public class RequisicaoSucessoRespostaPadraoModel<T>
    {
        public RequisicaoSucessoRespostaPadraoModel(T data)
        {
            Data = data;
            Valido = true;
        }

        public bool Valido { get; private set; }
        public T Data { get; private set; }
    }
}
