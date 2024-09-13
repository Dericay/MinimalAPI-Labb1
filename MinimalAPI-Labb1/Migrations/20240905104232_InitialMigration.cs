using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI_Labb1.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "BookTitle", "Description", "Genre", "IsAvailable", "Updated" },
                values: new object[,]
                {
                    { 1, "JK Rowling", "Harry Potter", "In the novels, Harry is described as having his father's perpetually untidy black hair, his mother's bright green eyes, and a lightning bolt-shaped scar on his forehead. He is short and skinny for his age, with a thin face and \"knobbly\" knees, and he wears Windsor glasses.", "Fantasy", true, null },
                    { 2, "Tolken", "Lord of the rings", "The plot of The Lord of the Rings is about the war of the peoples of the fantasy world Middle-earth against a dark lord known as \"Sauron.\" At the same time they try to destroy a ring which would give Sauron a lot of power if he got it, but the only place to destroy the ring is deep into Sauron's land Mordor.", "Fantasy", false, null },
                    { 3, "Robert Heinlein", "StarShip Troopers", "In the distant future, the Earth is at war with a race of giant alien insects. Little is known about the Bugs except that they are intent on the eradication of all human life. But there was a time before the war... A Mobile Infantry travels to distant alien planets to take the war to the Bugs. They are a ruthless enemy with only one mission: Survival of their species no matter what the cost...", "Sci-fi", false, null },
                    { 4, "Stephen King", "The Shining", " A family heads to an isolated hotel for the winter, where a sinister presence influences the father into violence. At the same time, his psychic son sees horrifying forebodings from both the past and the future.", "Horror", true, null },
                    { 5, "Lucy Foley", "The Guest List", "The story takes place at the wedding of Jules Keegan and Will Slater, which is being held on an island off the coast of Ireland. The plot has been compared to the works of Agatha Christie, as a murder occurs with limited suspects and each guest has a secret which will be revealed.", "Thriller", true, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
