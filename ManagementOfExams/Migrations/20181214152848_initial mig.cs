using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementOfExams.Migrations
{
    public partial class initialmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Exams_ExamId",
                table: "Subjects");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExamId",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TeacherIndexListingModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherIndexListingModel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Exams_ExamId",
                table: "Subjects",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Exams_ExamId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "TeacherIndexListingModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExamId",
                table: "Subjects",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Exams_ExamId",
                table: "Subjects",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
