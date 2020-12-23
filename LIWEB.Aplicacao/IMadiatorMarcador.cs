namespace LIWEB.Aplicacao
{
    /*
     * Interface criada para auxiliar no registro do IMediator. Quando o imediatr está
     * na api, a classe Startup é utilizada como ponto de referência para registrar os
     * handlers. Como os handlers está em outro projeto, é necessária uma classe de
     * referência. Poderia ser alguma classe já declarada, mas para não acoplar com
     * achei interessante criar uma interface de marcação somente para esta função. 
     *
     * https://github.com/jbogard/MediatR.Extensions.Microsoft.DependencyInjection
     *
     */
    public interface IMediatorMarcador
    {
    }
}