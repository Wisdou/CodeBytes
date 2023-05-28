using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeBytes.DAL.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemTags_Problems_ProblemEntityID",
                table: "ProblemTags");

            migrationBuilder.DropIndex(
                name: "IX_ProblemTags_ProblemEntityID",
                table: "ProblemTags");

            migrationBuilder.DropColumn(
                name: "ProblemEntityID",
                table: "ProblemTags");

            migrationBuilder.CreateTable(
                name: "ProblemEntityProblemTagEntity",
                columns: table => new
                {
                    ProblemID = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemEntityProblemTagEntity", x => new { x.ProblemID, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ProblemEntityProblemTagEntity_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemEntityProblemTagEntity_ProblemTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ProblemTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemEntityProblemTagEntity_TagsId",
                table: "ProblemEntityProblemTagEntity",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemEntityProblemTagEntity");

            migrationBuilder.AddColumn<int>(
                name: "ProblemEntityID",
                table: "ProblemTags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProblemTags_ProblemEntityID",
                table: "ProblemTags",
                column: "ProblemEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemTags_Problems_ProblemEntityID",
                table: "ProblemTags",
                column: "ProblemEntityID",
                principalTable: "Problems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
