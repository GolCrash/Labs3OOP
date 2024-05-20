using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudGame.Storage.Models
{
	[Index(nameof(NameOwn))]
	public class Owner
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid IsnNode { get; set; }

		[Required, MaxLength(255)]
		public string NameOwn { get; set; }

		[Required, MaxLength(255)]
		public DateTime DataRegistration { get; set; }

		[InverseProperty(nameof(Server.Owner))]
		public virtual ICollection<Server> Servers { get; set; }
	}
}