using System.ComponentModel.DataAnnotations;
using CloudGame.Properties;


namespace CloudGame.Features.DtoModels.Owner
{
    public sealed record OwnerDto
    {
        [Display(Name = "OwnerDto_IsnNode", ResourceType = typeof(Resources))]
        public Guid IsnNode { get; init; }

        [Display(Name = "OwnerDto_NameOwn", ResourceType = typeof(Resources))]
        public string NameOwn { get; init; }

        [Display(Name = "OwnerDto_DataRegistration", ResourceType = typeof(Resources))]
        public DateTime DataRegistration { get; init; }
    }
}
