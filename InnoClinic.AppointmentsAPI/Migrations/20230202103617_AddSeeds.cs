using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoClinic.AppointmentsAPI.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OfficeId",
                table: "Appointments",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DoctorId", "OfficeId", "PatientId", "ServiceId", "ServiceName", "Status", "Timeslots" },
                values: new object[,]
                {
                    { new Guid("54d11f1b-ef2b-4edd-906c-307b86e2da50"), new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4575b750-37e9-4194-ba18-b9219ac703b6"), "639990c96e070a016e91e332", new Guid("63a62769-de2a-4073-991f-c18f1a44df26"), new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"), "SomeName1", 0, "100" },
                    { new Guid("7c567279-5584-4aa3-bb02-7052e866eab3"), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4575b750-37e9-4194-ba18-b9219ac703b6"), "639990c96e070a016e91e332", new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"), new Guid("24d92a89-a088-4687-9947-08dac62592e6"), "SomeName2", 0, "100" },
                    { new Guid("b3b0d2b0-f0f1-46ab-87d2-52c7f29cd9b8"), new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e19b6bf-3c40-403c-a984-d713e300b0e7"), "639990c96e070a016e91e332", new Guid("63a62769-de2a-4073-991f-c18f1a44df26"), new Guid("24d92a89-a088-4687-9947-08dac62592e6"), "SomeName2", 0, "100" },
                    { new Guid("d38fce23-10a6-45e1-a253-907e4be5b6a4"), new DateTime(2023, 2, 2, 13, 36, 17, 10, DateTimeKind.Local).AddTicks(2932), new Guid("8e19b6bf-3c40-403c-a984-d713e300b0e7"), "639990c96e070a016e91e332", new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"), new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"), "SomeName1", 0, "100" },
                    { new Guid("f5549e81-765b-4f7f-a21f-584fd1dc942a"), new DateTime(2023, 2, 2, 13, 36, 17, 10, DateTimeKind.Local).AddTicks(2900), new Guid("4575b750-37e9-4194-ba18-b9219ac703b6"), "639990c96e070a016e91e332", new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"), new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"), "SomeName1", 0, "100" },
                    { new Guid("f84e6d4a-572e-46f1-909d-3ad50b02a88e"), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8e19b6bf-3c40-403c-a984-d713e300b0e7"), "639990c96e070a016e91e332", new Guid("61f80132-8914-4995-8c8f-cdabcd756d4c"), new Guid("24d92a89-a088-4687-9947-08dac62592e6"), "SomeName2", 0, "100" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("54d11f1b-ef2b-4edd-906c-307b86e2da50"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("7c567279-5584-4aa3-bb02-7052e866eab3"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("b3b0d2b0-f0f1-46ab-87d2-52c7f29cd9b8"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("d38fce23-10a6-45e1-a253-907e4be5b6a4"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f5549e81-765b-4f7f-a21f-584fd1dc942a"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("f84e6d4a-572e-46f1-909d-3ad50b02a88e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OfficeId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
