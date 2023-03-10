using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoClinic.AppointmentsAPI.Migrations
{
    public partial class ChangeTimeSlotType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timeslots",
                table: "Appointments");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Appointments",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("54d11f1b-ef2b-4edd-906c-307b86e2da50"),
                column: "Time",
                value: new TimeSpan(0, 13, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("7c567279-5584-4aa3-bb02-7052e866eab3"),
                column: "Time",
                value: new TimeSpan(0, 15, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("b3b0d2b0-f0f1-46ab-87d2-52c7f29cd9b8"),
                column: "Time",
                value: new TimeSpan(0, 11, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("d38fce23-10a6-45e1-a253-907e4be5b6a4"),
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2023, 2, 26, 14, 59, 36, 558, DateTimeKind.Local).AddTicks(2810), new TimeSpan(0, 14, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f5549e81-765b-4f7f-a21f-584fd1dc942a"),
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2023, 2, 26, 14, 59, 36, 558, DateTimeKind.Local).AddTicks(2781), new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f84e6d4a-572e-46f1-909d-3ad50b02a88e"),
                column: "Time",
                value: new TimeSpan(0, 12, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Timeslots",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("54d11f1b-ef2b-4edd-906c-307b86e2da50"),
                column: "Timeslots",
                value: "100");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("7c567279-5584-4aa3-bb02-7052e866eab3"),
                column: "Timeslots",
                value: "100");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("b3b0d2b0-f0f1-46ab-87d2-52c7f29cd9b8"),
                column: "Timeslots",
                value: "100");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("d38fce23-10a6-45e1-a253-907e4be5b6a4"),
                columns: new[] { "Date", "Timeslots" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 36, 17, 10, DateTimeKind.Local).AddTicks(2932), "100" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f5549e81-765b-4f7f-a21f-584fd1dc942a"),
                columns: new[] { "Date", "Timeslots" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 36, 17, 10, DateTimeKind.Local).AddTicks(2900), "100" });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f84e6d4a-572e-46f1-909d-3ad50b02a88e"),
                column: "Timeslots",
                value: "100");
        }
    }
}
