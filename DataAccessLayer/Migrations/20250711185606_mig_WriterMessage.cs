using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_WriterMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_writerMessages",
                table: "writerMessages");

            migrationBuilder.RenameTable(
                name: "writerMessages",
                newName: "WriterMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WriterMessages",
                table: "WriterMessages",
                column: "WriterMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WriterMessages",
                table: "WriterMessages");

            migrationBuilder.RenameTable(
                name: "WriterMessages",
                newName: "writerMessages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_writerMessages",
                table: "writerMessages",
                column: "WriterMessageId");
        }
    }
}
