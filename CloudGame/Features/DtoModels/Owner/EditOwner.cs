using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.Owner
{
    public class EditOwner
    {
        [Display(Name = "EditOwnerDto_IsnNode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "EditOwnerDto_NameOwn", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string NameOwn { get; init; }

        [Display(Name = "EditOwnerDto_DataRegistration", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]

        public DateTime DataRegistration { get; init; }
    }
}
