using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PresseMots_DataModels.Entities;


namespace PresseMots_DataAccess.Context
{
    public class PresseMotsDbContext : DbContext
    {



        public PresseMotsDbContext()
        {

        }

        public PresseMotsDbContext(DbContextOptions<PresseMotsDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("scaffolding");
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Share> Shares { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<StoryTag> StoryTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            #region Ne pas supprimer!
            modelBuilder.SetEntityRelationships();
            modelBuilder.GenerateData();

            base.OnModelCreating(modelBuilder);

            #endregion
        }

    }
}
