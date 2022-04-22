using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.MakeupCatalog.Migrations
{
    public partial class PopulateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into MakeupType(Name)" + "Values('Face')");
            migrationBuilder.Sql("Insert into MakeupType(Name)" + "Values('Eyes')");
            migrationBuilder.Sql("Insert into MakeupType(Name)" + "Values('Lips')");

            migrationBuilder.Sql("Insert into Products(Name, Color, Brand, Price, Description, MakeupTypeId)" +
                                 "Values('Soft Matte Lipstick', 'Ruby Woo', 'Mac', '80.00', 'The most beautiful red lipstick', " +
                                 "(Select MakeupTypeId from MakeupType where Name='Lips'))");

            migrationBuilder.Sql("Insert into Products(Name, Color, Brand, Price, MakeupTypeId)" +
                                 "Values('Soft Matte Lipstick', 'Burning Love', 'Mac', '80.00', " +
                                 "(Select MakeupTypeId from MakeupType where Name='Lips'))");

            migrationBuilder.Sql("Insert into Products(Name, Color, Brand, Price, Description, MakeupTypeId)" +
                                 "Values('Lash Mascara The Colossal', 'Black', 'Maybelline', '30.00', 'Now big volume meets bouncy curl. Colossal Curl Bounce mascara turns up the volume and curls up every lash without clumps. Up to 24HR wear', " +
                                 "(Select MakeupTypeId from MakeupType where Name='Eyes'))");

            migrationBuilder.Sql("Insert into Products(Name, Color, Brand, Price, Description, MakeupTypeId)" +
                                 "Values('Gloss Lip Luminizer', 'Cheeky', 'Fenty Beauty', '120.00', 'The ultimate gotta-have-it lip gloss with explosive shine that feels as good as it looks', " +
                                 "(Select MakeupTypeId from MakeupType where Name='Lips'))");

            migrationBuilder.Sql("Insert into Products(Name, Color, Brand, Price, Description, MakeupTypeId)" +
                                 "Values('Pro Filter Foundation', '#20', 'Fenty Beauty', '200.00', 'A soft matte foundation with medium coverage', " +
                                 "(Select MakeupTypeId from MakeupType where Name='Face'))");

            migrationBuilder.Sql("Insert into Products(Name, Color, Brand, Price, Description, MakeupTypeId)" +
                                 "Values('Pro Filter Foundation', '#30', 'Fenty Beauty', '200.00', 'A soft matte foundation with medium coverage', " +
                                 "(Select MakeupTypeId from MakeupType where Name='Face'))");

            migrationBuilder.Sql("Insert into Products(Name, Color, Brand, Price, Description, MakeupTypeId)" +
                                 "Values('Pro Filter Foundation', '#40', 'Fenty Beauty', '200.00', 'A soft matte foundation with medium coverage', " +
                                 "(Select MakeupTypeId from MakeupType where Name='Face'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from MakeupType");
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
