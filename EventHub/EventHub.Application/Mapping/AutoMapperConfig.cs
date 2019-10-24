using AutoMapper;

namespace EventHub.Application.Mapping
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(
                config => {
                    config.AddProfile<InputToEntity>();
                    config.AddProfile<DtoToViewModel>();
                }
            );
        }
    }
}
