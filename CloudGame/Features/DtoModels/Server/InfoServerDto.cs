using CloudGame.Features.DtoModels.Owner;
using CloudGame.Features.DtoModels.User;
using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.Server
{
    public class InfoServerDto
    {
        [Display(Name = "InfoServerDto_IsnNode", ResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "InfoServerDto_IsnOwner", ResourceType = typeof(Resources))]
        public Guid IsnOwner { get; init; }

        [Display(Name = "InfoServerDto_NameServer", ResourceType = typeof(Resources))]
        public string NameServer { get; init; }

        [Display(Name = "InfoServerDto_Games", ResourceType = typeof(Resources))]
        public string Games { get; init; }

        [Display(Name = "InfoServerDto_Сharacteristic", ResourceType = typeof(Resources))]
        public string Сharacteristic { get; init; }

        [Display(Name = "InfoServerDto_Users", ResourceType = typeof(Resources))]
        public UserDto[] Users { get; init; }

        [Display(Name = "InfoServerDto_Owner", ResourceType = typeof(Resources))]
        public OwnerDto Owners { get; init; }
    }
}
