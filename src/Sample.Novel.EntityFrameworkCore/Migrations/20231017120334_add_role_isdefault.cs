using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Novel.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addroleisdefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Sys_Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Sys_Roles");
        }
    }
}
