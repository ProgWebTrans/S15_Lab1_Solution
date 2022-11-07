using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresseMots_DataAccess.Migrations
{
    public partial class initData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEditTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Draft = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Hidden = table.Column<bool>(type: "bit", nullable: false),
                    StoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shares_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shares_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "snoopy@peanuts.com", null, "Snoopy" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Content", "CreationTime", "Draft", "LastEditTime", "OwnerId", "PublishTime", "Title" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\n\nNunc viverra imperdiet enim. Fusce est. Vivamus a tellus.\n\nPellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.\n\nAenean nec lorem. In porttitor. Donec laoreet nonummy augue.\n\nSuspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.\n", new DateTime(2021, 10, 4, 13, 12, 0, 0, DateTimeKind.Unspecified), false, null, 1, null, "Première publication" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Content", "CreationTime", "Draft", "LastEditTime", "OwnerId", "PublishTime", "Title" },
                values: new object[] { 2, "Les vidéos vous permettent de faire passer votre message de façon convaincante. Quand vous cliquez sur Vidéo en ligne, vous pouvez coller le code incorporé de la vidéo que vous souhaitez ajouter. Vous pouvez également taper un mot-clé pour rechercher en ligne la vidéo qui convient le mieux à votre document.\n\nPour donner un aspect professionnel à votre document, Word offre des conceptions d’en-tête, de pied de page, de page de garde et de zone de texte qui se complètent mutuellement. Vous pouvez par exemple ajouter une page de garde, un en-tête et une barre latérale identiques. Cliquez sur Insérer et sélectionnez les éléments de votre choix dans les différentes galeries.\n\nLes thèmes et les styles vous permettent également de structurer votre document. Quand vous cliquez sur Conception et sélectionnez un nouveau thème, les images, graphiques et SmartArt sont modifiés pour correspondre au nouveau thème choisi. Quand vous appliquez des styles, les titres changent pour refléter le nouveau thème.\n\nGagnez du temps dans Word grâce aux nouveaux boutons qui s'affichent quand vous en avez besoin. Si vous souhaitez modifier la façon dont une image s’ajuste à votre document, cliquez sur celle-ci pour qu’un bouton d’options de disposition apparaisse en regard de celle-ci. Quand vous travaillez sur un tableau, cliquez à l’emplacement où vous souhaitez ajouter une ligne ou une colonne, puis cliquez sur le signe plus.\n\nLa lecture est également simplifiée grâce au nouveau mode Lecture. Vous pouvez réduire certaines parties du document et vous concentrer sur le texte désiré. Si vous devez stopper la lecture avant d’atteindre la fin de votre document, Word garde en mémoire l’endroit où vous avez arrêté la lecture, même sur un autre appareil\n\n", new DateTime(2021, 10, 4, 13, 14, 0, 0, DateTimeKind.Unspecified), true, null, 1, null, "Utilité de MS Word" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DisplayName", "Email", "Hidden", "StoryId" },
                values: new object[] { 1, "Je trouve cet article un peu superficiel", "Thierry", "t.girouxveilleux@cegepmontpetit.ca", false, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DisplayName", "Email", "Hidden", "StoryId" },
                values: new object[] { 2, "Je suis d'accord", "Valérie", "v.turgeon@cegepmontpetit.ca", false, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DisplayName", "Email", "Hidden", "StoryId" },
                values: new object[] { 3, "C'est bizarre comme article. Ça ressemble au =rand() de word...", "Thierry", "t.girouxveilleux@cegepmontpetit.ca", false, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StoryId",
                table: "Comments",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_StoryId",
                table: "Likes",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_StoryId",
                table: "Shares",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shares_UserId",
                table: "Shares",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_OwnerId",
                table: "Stories",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Shares");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
