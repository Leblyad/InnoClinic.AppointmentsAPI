using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoClinic.AppointmentsAPI.Migrations
{
    public partial class AddDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("d38fce23-10a6-45e1-a253-907e4be5b6a4"),
                column: "Date",
                value: new DateTime(2023, 2, 26, 15, 11, 8, 73, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f5549e81-765b-4f7f-a21f-584fd1dc942a"),
                column: "Date",
                value: new DateTime(2023, 2, 26, 15, 11, 8, 73, DateTimeKind.Local).AddTicks(7182));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("d38fce23-10a6-45e1-a253-907e4be5b6a4"),
                column: "Date",
                value: new DateTime(2023, 2, 26, 14, 59, 36, 558, DateTimeKind.Local).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f5549e81-765b-4f7f-a21f-584fd1dc942a"),
                column: "Date",
                value: new DateTime(2023, 2, 26, 14, 59, 36, 558, DateTimeKind.Local).AddTicks(2781));
        }
    }
}
