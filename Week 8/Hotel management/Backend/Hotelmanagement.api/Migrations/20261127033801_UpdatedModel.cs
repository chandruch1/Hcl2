using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotelmanagement.api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Hotels",
                newName: "HotelPhoneNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelPhoneNo",
                table: "Hotels",
                newName: "PhoneNo");
        }
    }
}
