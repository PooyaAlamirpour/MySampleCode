namespace DomainLayer.ConfigurationModels
{
    public class CacheConfiguration
    {
        public bool UseRedis { get; set; }
        public bool UseLocalCache { get; set; }
    }
}