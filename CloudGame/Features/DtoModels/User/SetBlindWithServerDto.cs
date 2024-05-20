using CloudGame.Properties;
using System.ComponentModel.DataAnnotations;

namespace CloudGame.Features.DtoModels.User
{
    public class SetBlindWithServerDto
    {
        [Display(Name = "SetBlindWithServerDto_IsnUser", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public Guid IsnUser { get; init; }

        [Display(Name = "SetBlindWithServerDto_IsnServer", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources))]
        public Guid IsnServer { get; init; }
    }
}
