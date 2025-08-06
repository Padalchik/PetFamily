using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infractructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumnName_years_of_experience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearsOfExperience",
                table: "volunteers",
                newName: "years_of_experience");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "years_of_experience",
                table: "volunteers",
                newName: "YearsOfExperience");
        }
    }
}
