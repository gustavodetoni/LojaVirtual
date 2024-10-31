using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaVirtual.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) VALUES ('Clips', 29.99, 'Clip para papel', 50, 'clips.jpg', 1)");
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) VALUES ('Caneta Azul', 5.99, 'Caneta esferográfica azul', 150, 'caneta_azul.jpg', 2)");
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageUrl, CategoryId) VALUES ('Caderno Universitário', 19.90, 'Caderno de 200 folhas', 75, 'caderno.jpg', 3)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
