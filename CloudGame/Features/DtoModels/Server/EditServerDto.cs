using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.Server
{
    public class EditServerDto
    {
        [Display(Name = "EditServerDto_IsnNode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "EditServerDto_IsnOwner", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public Guid IsnOwner { get; init; }

        [Display(Name = "EditServerDto_NameServer", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string NameServer { get; init; }

        [Display(Name = "EditServerDto_Games", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Games { get; init; }

        [Display(Name = "EditServerDto_Сharacteristic", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Сharacteristic { get; init; }
    }
}
