using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleLNU.DataAccess.Migrations
{
    public partial class UpdateEventStylesForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsStyles_Students_StudentId",
                table: "EventsStyles");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "EventsStyles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsStyles_Students_StudentId",
                table: "EventsStyles",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsStyles_Students_StudentId",
                table: "EventsStyles");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "EventsStyles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsStyles_Students_StudentId",
                table: "EventsStyles",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
