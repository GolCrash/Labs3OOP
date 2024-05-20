using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Storage.Models
{
	[Index(nameof(NameServer), nameof(IsnOwner))]
	public class Server
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid IsnNode { get; set; }

		[ForeignKey(nameof(Owner))]
		public Guid IsnOwner { get; set; }

		[Required, MaxLength(255)]
		public string NameServer { get; set; }

		[Required, MaxLength(255)]
		public string Games { get; set; }

		[Required, MaxLength(255)]
		public string Сharacteristic { get; set; }

		[InverseProperty(nameof(User_Server.Server))]
		public virtual ICollection<User_Server> ServerUser { get; set; }

		public virtual Owner Owner { get; set; }


	}
}