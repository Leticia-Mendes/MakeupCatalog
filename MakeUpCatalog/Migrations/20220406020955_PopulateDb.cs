using Microsoft.EntityFrameworkCore.Migrations;

namespace MakeupCatalog.Migrations
{
    public partial class PopulateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Product(Name, MakeupType, Color, Brand, Price, Description)" +
                                 "Values('Soft Matte Lipstick', 3, 'Red', 'Mac', '80.00', 'The most beautiful red lipstick')");

            migrationBuilder.Sql("Insert into Product(Name, MakeupType, Color, Brand, Price, Description)" +
                                 "Values('Pro Filter Foundation', 1, '#20', 'Fenty Beauty', '200.00', 'A soft matte foundation with medium coverage')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Product");
        }
    }
}
