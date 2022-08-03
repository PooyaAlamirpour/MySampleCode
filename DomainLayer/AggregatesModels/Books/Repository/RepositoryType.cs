namespace DomainLayer.AggregatesModels.Books.Repository
{
    public enum RepositoryType
    {
        MEMORY,
        REDIS,
        FILE,
        HTTP
    }
    
    public enum RepositoryRemoteType
    {
        TAAGHCHE_SERVICE_1
    }
}