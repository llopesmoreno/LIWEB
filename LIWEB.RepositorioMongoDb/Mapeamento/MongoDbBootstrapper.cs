namespace LIWEB.RepositorioMongoDb.Mapeamento
{
    public static class MongoDbBootstrapper
    {
        public static void InicializarMapeamentos()
        {
            new UsuarioMapeamento();
        }
    }
}
