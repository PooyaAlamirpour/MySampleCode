using AutoMapper;

namespace ApplicationLayer.MappingConfigurations
{
    public class AutoMapping
    {
        public static MapperConfiguration RegisterMappings() => new(cfg =>
        {
            cfg.AddProfile(new MappingEntityToDtoProfile());
        });
    }
}