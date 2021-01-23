using Microsoft.EntityFrameworkCore.Migrations;

namespace PortlandAnimalShelter.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "AdoptFee", "Age", "Breed", "Color", "Gender", "Name", "Personality", "Weight" },
                values: new object[,]
                {
                    { 1, 25f, 10, "Short-Hair Domestic", "Grey, White", "Female", "Bulma", "affectionate and social", 11f },
                    { 2, 100f, 12, "Short-Hair Domestic", "Black with stars", "Male", "Dusty", "loyal, independent", 8f },
                    { 3, 170f, 6, "Short-Hair Domestic", "Orange Tabby", "Female", "Spot", "cautious of strangers, affectionate", 8f }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "AdoptFee", "Age", "Breed", "Color", "Gender", "Name", "Personality", "Weight" },
                values: new object[,]
                {
                    { 1, 250f, 3, "Pembroke Corgi", "Red", "Male", "Ein", "affectionate and social", 27f },
                    { 2, 200f, 8, "Shiba Inu", "Red, Tan", "Male", "Hachiko", "loyal, independent", 20f },
                    { 3, 170f, 7, "Siberian Husky", "Black, White", "Male", "Balto", "active, loyal, strong willed", 48f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "DogId",
                keyValue: 3);
        }
    }
}
