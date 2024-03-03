using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class deleteAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<string>(type: "longtext", nullable: false, comment: "合作商名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Relation = table.Column<int>(type: "int", nullable: false, comment: "關係"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                },
                comment: "贊助/合作商")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_CreateTime",
                table: "Partner",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_DeleteTime",
                table: "Partner",
                column: "DeleteTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "年齡");
        }
    }
}
