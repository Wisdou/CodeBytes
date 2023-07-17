using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeBytes.DAL.Migrations
{
    public partial class PostgreSQLTextExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION pg_trgm;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP EXTENSION pg_trgm;");
        }
    }
}
