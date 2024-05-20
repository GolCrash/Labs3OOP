using CloudGame.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudGame.Storage.Database;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions options) : base(options)
	{

	}

	public virtual DbSet<Owner> Owners { get; set; }

	public virtual DbSet<Server> Servers {  get; set; }

	public virtual DbSet<User> Users { get; set; }

	public virtual DbSet<User_Server> User_Servers { get; set; }
}
