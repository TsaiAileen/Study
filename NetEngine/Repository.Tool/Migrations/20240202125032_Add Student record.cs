using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentrecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<string>(type: "longtext", nullable: false, comment: "姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "年齡"),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false, comment: "生日"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "删除时间"),
                    RowVersion = table.Column<uint>(type: "int unsigned", rowVersion: true, nullable: false, comment: "行版本标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                },
                comment: "學生紀錄表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreateTime",
                table: "Student",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DeleteTime",
                table: "Student",
                column: "DeleteTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
