using Microservise.Data;
using Microservise.Web.Infrastructure.Mappers.Base;
using Microservise.Web.ViewModels.AccountViewModels;

namespace Microservise.Web.Infrastructure.Mappers
{
    /// <summary>
    /// Mapper Configuration for entity Person
    /// </summary>
    public class ApplicationUserProfileMapperConfiguration : MapperConfigurationBase
    {
        /// <inheritdoc />
        public ApplicationUserProfileMapperConfiguration()
        {
            CreateMap<RegisterViewModel, ApplicationUserProfile>()
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}