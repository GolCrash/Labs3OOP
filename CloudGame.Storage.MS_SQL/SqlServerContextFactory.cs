using CloudGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CloudGame.Storage.MS_SQL
{
	public class SqlServerContextFactory : IDesignTimeDbContextFactory<DataContext>
	{
		private const string DbConnectionString = "Server=localhost, Port=1433;Database=CloudGaming; User ID=sa; Password=<MyVeryStrong@Passw0rd>;MultipleActiveResultSets=true;TrustServerCertificate=True";

		public DataContext CreateDbContext(string[] args)
		{
			var optionBuilder = new DbContextOptionsBuilder<DataContext>();

			optionBuilder.UseSqlServer(DbConnectionString, b => b.MigrationsAssembly(typeof(SqlServerContextFactory).Namespace));

			return new DataContext(optionBuilder.Options);
		}
	}
}
