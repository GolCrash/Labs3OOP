using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.Server
{
    public sealed record ServerDto
    {
        [Display(Name = "ServerDto_IsnNode", ResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "ServerDto_IsnOwner", ResourceType = typeof(Resources))]
        public Guid IsnOwner { get; init; }

        [Display(Name = "ServerDto_NameServer", ResourceType = typeof(Resources))]
        public string NameServer { get; init; }

        [Display(Name = "ServerDto_Games", ResourceType = typeof(Resources))]
        public string Games { get; init; }

        [Display(Name = "ServerDto_Сharacteristic", ResourceType = typeof(Resources))]
        public string Сharacteristic { get; init; }
    }
}