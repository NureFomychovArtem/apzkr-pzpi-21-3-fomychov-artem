using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseRoleRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChangingRoles",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditSchool",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditStudent",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditTeacher",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VisitMark",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql("INSERT INTO Roles (Name, EditStudent, EditTeacher, EditSchool, VisitMark, ChangingRoles) VALUES  (0, 0, 0, 0, 0, 0);" +
                "INSERT INTO Roles (Name, EditStudent, EditTeacher, EditSchool, VisitMark, ChangingRoles) VALUES  (1, 1, 1, 1, 1, 1);" +
                "INSERT INTO Roles (Name, EditStudent, EditTeacher, EditSchool, VisitMark, ChangingRoles) VALUES  (2, 1, 0, 0, 1, 0);" +
                "INSERT INTO Roles (Name, EditStudent, EditTeacher, EditSchool, VisitMark, ChangingRoles) VALUES  (3, 0, 0, 0, 1, 0);" +
                "INSERT INTO Roles (Name, EditStudent, EditTeacher, EditSchool, VisitMark, ChangingRoles) VALUES  (4, 0, 0, 0, 0, 0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangingRoles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EditSchool",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EditStudent",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EditTeacher",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "VisitMark",
                table: "Roles");
        }
    }
}
