using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Request_RequestId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Users_AuthorId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Users_UserId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Classrooms_ClassroomId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Users_AuthorId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Clasess_ClassId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Users_UserId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Clasess_ClassId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Classrooms_ClassroomId",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Users_UserId",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_UserId",
                table: "Teachers",
                newName: "IX_Teachers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_ClassroomId",
                table: "Teachers",
                newName: "IX_Teachers_ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_ClassId",
                table: "Teachers",
                newName: "IX_Teachers_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_UserId",
                table: "Students",
                newName: "IX_Students_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ClassId",
                table: "Students",
                newName: "IX_Students_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ClassroomId",
                table: "Requests",
                newName: "IX_Requests_ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_AuthorId",
                table: "Requests",
                newName: "IX_Requests_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_UserId",
                table: "Attendances",
                newName: "IX_Attendances_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_RequestId",
                table: "Answers",
                newName: "IX_Answers_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_AuthorId",
                table: "Answers",
                newName: "IX_Answers_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Requests_RequestId",
                table: "Answers",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_AuthorId",
                table: "Answers",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Users_UserId",
                table: "Attendances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Classrooms_ClassroomId",
                table: "Requests",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_AuthorId",
                table: "Requests",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Clasess_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Clasess",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Clasess_ClassId",
                table: "Teachers",
                column: "ClassId",
                principalTable: "Clasess",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classrooms_ClassroomId",
                table: "Teachers",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_UserId",
                table: "Teachers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Requests_RequestId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_AuthorId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Users_UserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Classrooms_ClassroomId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_AuthorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Clasess_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Clasess_ClassId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classrooms_ClassroomId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_UserId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_UserId",
                table: "Teacher",
                newName: "IX_Teacher_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_ClassroomId",
                table: "Teacher",
                newName: "IX_Teacher_ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_ClassId",
                table: "Teacher",
                newName: "IX_Teacher_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_UserId",
                table: "Student",
                newName: "IX_Student_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassId",
                table: "Student",
                newName: "IX_Student_ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_ClassroomId",
                table: "Request",
                newName: "IX_Request_ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_AuthorId",
                table: "Request",
                newName: "IX_Request_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_UserId",
                table: "Attendance",
                newName: "IX_Attendance_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_RequestId",
                table: "Answer",
                newName: "IX_Answer_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_AuthorId",
                table: "Answer",
                newName: "IX_Answer_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Request_RequestId",
                table: "Answer",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Users_AuthorId",
                table: "Answer",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Users_UserId",
                table: "Attendance",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Classrooms_ClassroomId",
                table: "Request",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Users_AuthorId",
                table: "Request",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Clasess_ClassId",
                table: "Student",
                column: "ClassId",
                principalTable: "Clasess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Users_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Clasess_ClassId",
                table: "Teacher",
                column: "ClassId",
                principalTable: "Clasess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Classrooms_ClassroomId",
                table: "Teacher",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Users_UserId",
                table: "Teacher",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
