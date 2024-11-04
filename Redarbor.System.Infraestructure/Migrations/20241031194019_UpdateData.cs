using Microsoft.EntityFrameworkCore.Migrations;
using Redarbor.System.Domain.Entities;

#nullable disable

namespace Redarbor.System.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: nameof(CompanyEntity),
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Redarbor" },
                });

            migrationBuilder.InsertData(
                table: nameof(PortalEntity),
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Principal" },
                });

            migrationBuilder.InsertData(
                table: nameof(RoleEntity),
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Manager" },
                });
            migrationBuilder.InsertData(
                table: nameof(StatusEntity),
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Active" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}