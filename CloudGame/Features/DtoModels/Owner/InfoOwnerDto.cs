using CloudGame.Features.DtoModels.Server;
using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;


namespace CloudGame.Features.DtoModels.Owner
{
    public class InfoOwnerDto
    {
        [Display(Name = "InfoOwnerDto_IsnNode", ResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "InfoOwnerDto_NameOwn", ResourceType = typeof(Resources))]
        public string NameOwn { get; init; }

        [Display(Name = "InfoOwnerDto_DataRegistration", ResourceType = typeof(Resources))]
        public DateTime DataRegistration { get; init; }

        [Display(Name = "InfoOwnerDto_Servers", ResourceType = typeof(Resources))]
        public ServerDto[] Servers { get; init; }
    }
}


