using AutoMapper;

namespace App.Services.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
