using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.EFC.Migrations
{
    /// <inheritdoc />
    public partial class AddInstructorRoleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Instructors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "InstructorRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_RoleId",
                table: "Instructors",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_InstructorRoles_RoleId",
                table: "Instructors",
                column: "RoleId",
                principalTable: "InstructorRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_InstructorRoles_RoleId",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "InstructorRoles");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_RoleId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Instructors");
        }
    }
}
