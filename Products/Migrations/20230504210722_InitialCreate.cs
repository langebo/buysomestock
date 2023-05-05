using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Products.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Isin", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("03b9eb7c-e3e4-4fa2-8369-cf330387c9ce"), "DE00N5N6OP4H", 763.394181566851990m, "Hills - Tillman" },
                    { new Guid("0d0cba07-3475-4b62-bc2e-ba5f2e13fe2c"), "DE00XF72D6Y4", 167.841819268374340m, "Thompson, Goyette and Romaguera" },
                    { new Guid("17af5ff4-10a2-498d-a562-60562c20071b"), "DE00C7YRQ00I", 349.626823238713780m, "Champlin Inc" },
                    { new Guid("1cc1aa39-dee5-4a5a-94c3-821ccfd2806a"), "DE00R63EBL9L", 360.842036462723080m, "Schowalter, Botsford and Frami" },
                    { new Guid("23914259-ba1d-4c9a-a94e-22db6fa3c6b8"), "DE00U4E4664K", 920.346896981999620m, "Abbott, Feeney and Koelpin" },
                    { new Guid("2a402d39-3cb1-450a-9057-ae0081c16049"), "DE000PVZ00QY", 677.349042834036970m, "Hamill LLC" },
                    { new Guid("2a810d45-882d-4279-8092-a5fee4f31691"), "DE00KD0HPWCB", 766.329395152307680m, "Sipes, Greenholt and Champlin" },
                    { new Guid("30d3d748-84cd-4126-93cf-9ad9d38347e0"), "DE00315JY9X7", 34.8890010860049130m, "Cassin - Hamill" },
                    { new Guid("3960d4dd-274c-4e54-ba0e-bc3b637ec7fc"), "DE00757D8Q5D", 574.118450664372010m, "Shields and Sons" },
                    { new Guid("5882c705-2e9d-45f5-b4be-080c1a4815c4"), "DE00E5V2891S", 16.25582765740828060m, "Berge - Jerde" },
                    { new Guid("5c9990ac-ff69-4ba6-bcb9-9bd1d908803d"), "DE00VR9U7V5N", 348.200917795951210m, "Altenwerth and Sons" },
                    { new Guid("5e233ecf-c3a1-4fba-baef-885e505dcaa4"), "DE00MA9S3BFJ", 211.613140234917730m, "Schinner, Hilll and Denesik" },
                    { new Guid("5e8a2747-ab57-4c71-90ba-57244de9ba88"), "DE00LU2S9UG6", 544.665654871025590m, "Casper and Sons" },
                    { new Guid("60b5bfec-f8e6-4592-8be3-bed9e254afc2"), "DE00F1474TZ2", 493.72944490833490m, "Schaden - Rolfson" },
                    { new Guid("614abe09-ca79-4426-a1df-837f677faf44"), "DE006OBNO29U", 499.5431002553410m, "Block Inc" },
                    { new Guid("63317d37-9198-409e-8c71-87b902a298c0"), "DE00YJR4I23V", 615.808702795151350m, "Hirthe LLC" },
                    { new Guid("6727b4e3-fdf8-4eeb-937c-c872e8f93db8"), "DE0095V3LZZR", 810.557975668218130m, "Nader - Beahan" },
                    { new Guid("7ffd0b7e-81b3-4499-9da7-6310cfa6f216"), "DE00YDGV6TD6", 837.49883761073980m, "Greenholt - Ondricka" },
                    { new Guid("841a69de-53c6-4ee8-8d46-94697e95e512"), "DE00O9QH4PP9", 359.885726723255140m, "Emmerich and Sons" },
                    { new Guid("8e711d26-e8f2-49f9-812b-77bc21172c7a"), "DE00CR1213E3", 618.21058415693950m, "Lockman and Sons" },
                    { new Guid("9a67ba95-2df7-44dd-b444-194af96d0e36"), "DE00PVUWGE67", 531.743022308992330m, "Kshlerin Group" },
                    { new Guid("aaf1ef4c-f248-4260-833e-6447f0c523e1"), "DE00607R4DC6", 182.759286513920590m, "Bernhard, Kunze and Oberbrunner" },
                    { new Guid("b3db6a47-850d-434c-b417-d2756a7b4578"), "DE009J6Z0LLD", 92.3625567435425590m, "Toy, Blick and Schoen" },
                    { new Guid("b8aed924-935f-4acc-96d8-9776f521351c"), "DE00SWWU7HPV", 967.704472196563960m, "Denesik, Zieme and Douglas" },
                    { new Guid("ba6a1887-c2b6-4d1a-84d6-c2737a19d40e"), "DE006W43N0OK", 772.556018532670450m, "Koepp and Sons" },
                    { new Guid("c728db82-81a3-48f8-a522-a211bb9a2972"), "DE00K6E02259", 724.57966693718110m, "Kuphal and Sons" },
                    { new Guid("f3999491-8a38-46ec-baaf-891bf8cd3fe3"), "DE00VI1KMJ0D", 508.124667141811270m, "Mante, Paucek and Kertzmann" },
                    { new Guid("f5947ec4-d3e0-45b5-9b7b-2807f980e530"), "DE00O46S87DR", 565.617849190565590m, "Kautzer LLC" },
                    { new Guid("f6914d50-6478-4232-9d7d-65942cb6ad80"), "DE00UN5VEVOE", 472.517687575705960m, "Quitzon Inc" },
                    { new Guid("fd9dcb51-9592-46b0-9930-f52cf8c836a3"), "DE00U11I7T92", 621.611164553539150m, "Yundt - Rowe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
