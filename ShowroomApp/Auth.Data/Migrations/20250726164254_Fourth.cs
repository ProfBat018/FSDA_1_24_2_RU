using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_FK_UserRoles_Role",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_FK_UserRoles_User",
                table: "UserRoles");
            
            migrationBuilder.DropColumn(
                name: "FK_UserRoles_Role",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "FK_UserRoles_User",
                table: "UserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.AddColumn<string>(
                name: "FK_UserRoles_Role",
                table: "UserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FK_UserRoles_User",
                table: "UserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_FK_UserRoles_Role",
                table: "UserRoles",
                column: "FK_UserRoles_Role");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_FK_UserRoles_User",
                table: "UserRoles",
                column: "FK_UserRoles_User");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_FK_UserRoles_Role",
                table: "UserRoles",
                column: "FK_UserRoles_Role",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_FK_UserRoles_User",
                table: "UserRoles",
                column: "FK_UserRoles_User",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
