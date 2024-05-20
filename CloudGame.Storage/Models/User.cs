using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CloudGame.Storage.Models
{
	[Index(nameof(NameUser))]
	public class User
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid IsnNode { get; set; }

		[Required, MaxLength(255)]
		public string NameUser { get; set; }

		[Required, MaxLength(255)]
		public string Tariff { get; set; }

		[InverseProperty(nameof(User_Server.User))]
		public virtual ICollection<User_Server> UserServer { get; set; }
	}
}