using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class iteachDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassItem",
                columns: table => new
                {
                    IdClass = table.Column<int>(type: "int", nullable: false),
                    NameSemester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEnroll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassItem", x => x.IdClass);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentItem",
                columns: table => new
                {
                    IdEnroll = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    NameEnrole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentItem", x => x.IdEnroll);
                });

            migrationBuilder.CreateTable(
                name: "ModuleItem",
                columns: table => new
                {
                    IdModule = table.Column<int>(type: "int", nullable: false),
                    NameModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleItem", x => x.IdModule);
                });

            migrationBuilder.CreateTable(
                name: "TaskItem",
                columns: table => new
                {
                    IdTask = table.Column<int>(type: "int", nullable: false),
                    NameTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreTask = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.IdTask);
                });

            migrationBuilder.CreateTable(
                name: "UserItem",
                columns: table => new
                {
                    IdModule = table.Column<int>(type: "int", nullable: false),
                    IdEnroll = table.Column<int>(type: "int", nullable: false),
                    IdTask = table.Column<int>(type: "int", nullable: false),
                    IdClass = table.Column<int>(type: "int", nullable: false),
                    DniUser = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurnameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItem", x => x.IdModule);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassItem");

            migrationBuilder.DropTable(
                name: "EnrollmentItem");

            migrationBuilder.DropTable(
                name: "ModuleItem");

            migrationBuilder.DropTable(
                name: "TaskItem");

            migrationBuilder.DropTable(
                name: "UserItem");
        }
    }
}
