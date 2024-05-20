using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.User
{
    public class EditUserDto
    {
        [Display(Name = "EditUserDto_IsnNode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "EditUserDto_NameUser", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string NameUser { get; init; }

        [Display(Name = "EditUserDto_Tariff", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Tariff { get; init; }
    }
}
