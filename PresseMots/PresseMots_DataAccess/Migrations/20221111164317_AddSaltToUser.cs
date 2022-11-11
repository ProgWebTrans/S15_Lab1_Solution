using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresseMots_DataAccess.Migrations
{
    public partial class AddSaltToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\r\n\r\nNunc viverra imperdiet enim. Fusce est. Vivamus a tellus.\r\n\r\nPellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.\r\n\r\nAenean nec lorem. In porttitor. Donec laoreet nonummy augue.\r\n\r\nSuspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.\r\n");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Les vidéos vous permettent de faire passer votre message de façon convaincante. Quand vous cliquez sur Vidéo en ligne, vous pouvez coller le code incorporé de la vidéo que vous souhaitez ajouter. Vous pouvez également taper un mot-clé pour rechercher en ligne la vidéo qui convient le mieux à votre document.\r\n\r\nPour donner un aspect professionnel à votre document, Word offre des conceptions d’en-tête, de pied de page, de page de garde et de zone de texte qui se complètent mutuellement. Vous pouvez par exemple ajouter une page de garde, un en-tête et une barre latérale identiques. Cliquez sur Insérer et sélectionnez les éléments de votre choix dans les différentes galeries.\r\n\r\nLes thèmes et les styles vous permettent également de structurer votre document. Quand vous cliquez sur Conception et sélectionnez un nouveau thème, les images, graphiques et SmartArt sont modifiés pour correspondre au nouveau thème choisi. Quand vous appliquez des styles, les titres changent pour refléter le nouveau thème.\r\n\r\nGagnez du temps dans Word grâce aux nouveaux boutons qui s'affichent quand vous en avez besoin. Si vous souhaitez modifier la façon dont une image s’ajuste à votre document, cliquez sur celle-ci pour qu’un bouton d’options de disposition apparaisse en regard de celle-ci. Quand vous travaillez sur un tableau, cliquez à l’emplacement où vous souhaitez ajouter une ligne ou une colonne, puis cliquez sur le signe plus.\r\n\r\nLa lecture est également simplifiée grâce au nouveau mode Lecture. Vous pouvez réduire certaines parties du document et vous concentrer sur le texte désiré. Si vous devez stopper la lecture avant d’atteindre la fin de votre document, Word garde en mémoire l’endroit où vous avez arrêté la lecture, même sur un autre appareil\r\n\r\n");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.\n\nNunc viverra imperdiet enim. Fusce est. Vivamus a tellus.\n\nPellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.\n\nAenean nec lorem. In porttitor. Donec laoreet nonummy augue.\n\nSuspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.\n");

            migrationBuilder.UpdateData(
                table: "Stories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Les vidéos vous permettent de faire passer votre message de façon convaincante. Quand vous cliquez sur Vidéo en ligne, vous pouvez coller le code incorporé de la vidéo que vous souhaitez ajouter. Vous pouvez également taper un mot-clé pour rechercher en ligne la vidéo qui convient le mieux à votre document.\n\nPour donner un aspect professionnel à votre document, Word offre des conceptions d’en-tête, de pied de page, de page de garde et de zone de texte qui se complètent mutuellement. Vous pouvez par exemple ajouter une page de garde, un en-tête et une barre latérale identiques. Cliquez sur Insérer et sélectionnez les éléments de votre choix dans les différentes galeries.\n\nLes thèmes et les styles vous permettent également de structurer votre document. Quand vous cliquez sur Conception et sélectionnez un nouveau thème, les images, graphiques et SmartArt sont modifiés pour correspondre au nouveau thème choisi. Quand vous appliquez des styles, les titres changent pour refléter le nouveau thème.\n\nGagnez du temps dans Word grâce aux nouveaux boutons qui s'affichent quand vous en avez besoin. Si vous souhaitez modifier la façon dont une image s’ajuste à votre document, cliquez sur celle-ci pour qu’un bouton d’options de disposition apparaisse en regard de celle-ci. Quand vous travaillez sur un tableau, cliquez à l’emplacement où vous souhaitez ajouter une ligne ou une colonne, puis cliquez sur le signe plus.\n\nLa lecture est également simplifiée grâce au nouveau mode Lecture. Vous pouvez réduire certaines parties du document et vous concentrer sur le texte désiré. Si vous devez stopper la lecture avant d’atteindre la fin de votre document, Word garde en mémoire l’endroit où vous avez arrêté la lecture, même sur un autre appareil\n\n");
        }
    }
}
