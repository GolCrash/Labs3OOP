using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Storage.Models
{
	[Index(nameof(IsnServer), nameof(IsnUser))]
	[PrimaryKey(nameof(IsnServer), nameof(IsnUser))]
	public class User_Server
	{
		[ForeignKey(nameof(Server)), Required]
		public Guid IsnServer { get; set; }

		[ForeignKey(nameof(User)), Required]
		public Guid IsnUser { get; set; }

		public virtual Server Server { get; set; }

		public virtual User User { get; set; }
	}
}