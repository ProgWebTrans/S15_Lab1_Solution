using System;
using Microsoft.EntityFrameworkCore;
using PresseMots_DataModels.Entities;


namespace PresseMots_DataAccess.Context
{
    public static class ModelBuilderDataGenerator
    {
        public static void SetEntityRelationships(this ModelBuilder builder) {
            builder
           .Entity<Share>()
           .HasOne(e => e.User)
           .WithMany(e => e.Shares)
           .OnDelete(DeleteBehavior.Restrict);
            
            builder
           .Entity<Like>()
           .HasOne(e => e.User)
           .WithMany(e => e.Likes)
           .OnDelete(DeleteBehavior.Restrict);




        }
        public static void GenerateData(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User() { Id = 1, Username = "Snoopy", Email = "snoopy@peanuts.com" },
                new User() { Id = 2, Username = "Chocolat", Email = "chocolat@peanuts.com" }
                );
            builder.Entity<Story>().HasData(new Story() { Id = 1, OwnerId = 1, Title = "Première publication", Content = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.

Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.

Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.

Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.

Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.
", CreationTime = new DateTime(2021, 10, 04, 13, 12, 00), Draft = false },
new Story() { Id = 2, OwnerId = 1, Title = "Utilité de MS Word", Content = @"Les vidéos vous permettent de faire passer votre message de façon convaincante. Quand vous cliquez sur Vidéo en ligne, vous pouvez coller le code incorporé de la vidéo que vous souhaitez ajouter. Vous pouvez également taper un mot-clé pour rechercher en ligne la vidéo qui convient le mieux à votre document.

Pour donner un aspect professionnel à votre document, Word offre des conceptions d’en-tête, de pied de page, de page de garde et de zone de texte qui se complètent mutuellement. Vous pouvez par exemple ajouter une page de garde, un en-tête et une barre latérale identiques. Cliquez sur Insérer et sélectionnez les éléments de votre choix dans les différentes galeries.

Les thèmes et les styles vous permettent également de structurer votre document. Quand vous cliquez sur Conception et sélectionnez un nouveau thème, les images, graphiques et SmartArt sont modifiés pour correspondre au nouveau thème choisi. Quand vous appliquez des styles, les titres changent pour refléter le nouveau thème.

Gagnez du temps dans Word grâce aux nouveaux boutons qui s'affichent quand vous en avez besoin. Si vous souhaitez modifier la façon dont une image s’ajuste à votre document, cliquez sur celle-ci pour qu’un bouton d’options de disposition apparaisse en regard de celle-ci. Quand vous travaillez sur un tableau, cliquez à l’emplacement où vous souhaitez ajouter une ligne ou une colonne, puis cliquez sur le signe plus.

La lecture est également simplifiée grâce au nouveau mode Lecture. Vous pouvez réduire certaines parties du document et vous concentrer sur le texte désiré. Si vous devez stopper la lecture avant d’atteindre la fin de votre document, Word garde en mémoire l’endroit où vous avez arrêté la lecture, même sur un autre appareil

", CreationTime = new DateTime(2021, 10, 04, 13, 14, 00), Draft = true });

            builder.Entity<Comment>().HasData(
                new Comment() { Id = 1, Content = "Je trouve cet article un peu superficiel", DisplayName = "Thierry", Email = "t.girouxveilleux@cegepmontpetit.ca", Hidden = false, StoryId = 1 },
                new Comment() { Id = 2, Content = "Je suis d'accord", DisplayName = "Valérie", Email = "v.turgeon@cegepmontpetit.ca", Hidden = false, StoryId = 1 },
            new Comment() { Id = 3, Content = "C'est bizarre comme article. Ça ressemble au =rand() de word...", DisplayName = "Thierry", Email = "t.girouxveilleux@cegepmontpetit.ca", Hidden = false, StoryId = 2 });

            builder.Entity<Like>().HasData(
                new Like() { Id = 1, StoryId = 1, UserId = 2 }

                );


            builder.Entity<Share>().HasData(
                new Share() { Id = 1, StoryId = 1, UserId = 2 }

                );
        }

        
    }
}
