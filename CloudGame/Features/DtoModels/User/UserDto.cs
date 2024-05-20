using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.User
{
    public class UserDto
    {
        [Display(Name = "UserDto_IsnNode", ResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "UserDto_NameUser", ResourceType = typeof(Resources))]
        public string NameUser { get; init; }

        [Display(Name = "UserDto_Tariff", ResourceType = typeof(Resources))]
        public string Tariff { get; init; }
    }
}
