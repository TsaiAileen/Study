using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class AddStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserBindExternal");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TaskSetting");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "QueueTask");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "FunctionRoute");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "FunctionAuthorize");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "File");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "DataUpdateLog");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AppSetting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "UserToken",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "UserRole",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "UserInfo",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "UserBindExternal",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "User",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "TaskSetting",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Student",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Role",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "QueueTask",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Product",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "OrderDetail",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Order",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Log",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Link",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "FunctionRoute",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "FunctionAuthorize",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Function",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "File",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "DataUpdateLog",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Category",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "Article",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");

            migrationBuilder.AddColumn<uint>(
                name: "RowVersion",
                table: "AppSetting",
                type: "int unsigned",
                rowVersion: true,
                nullable: false,
                defaultValue: 0u,
                comment: "行版本标记");
        }
    }
}
