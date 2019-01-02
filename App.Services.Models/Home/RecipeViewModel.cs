using App.Services.Mapping;
using AutoMapper;

namespace App.Services.Models.Home
{
    public class IndexRecipeViewModel : IMapFrom<App.Models.Recipe>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<App.Models.Recipe, IndexRecipeViewModel>()
                .ForMember(x => x.Url, x => x.MapFrom(r => r.SmallPictureUrl));
        }
    }

}
