using FluentMigrator;

namespace JeffSingleton.Database.Migrations._1
{
	[Migration(1)]
	public class Baseline : Migration
	{
		public override void Up()
		{
			Execute.Script("1\\baseline.sql");
		}

		public override void Down() { }
	}
}