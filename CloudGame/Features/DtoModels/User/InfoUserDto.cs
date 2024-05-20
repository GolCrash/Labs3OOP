using CloudGame.Features.DtoModels.Server;
using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.User
{
    public class InfoUserDto
    {
        [Display(Name = "InfoUserDto_IsnNode", ResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "InfoUserDto_NameUser", ResourceType = typeof(Resources))]
        public string NameUser { get; init; }

        [Display(Name = "InfoUserDto_Tariff", ResourceType = typeof(Resources))]
        public string Tariff { get; init; }

        [Display(Name = "InfoUserDto_Servers", ResourceType = typeof(Resources))]
        public ServerDto[] Servers { get; init; }
    }
}
