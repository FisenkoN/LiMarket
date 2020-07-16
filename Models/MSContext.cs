using System.Data.Entity;

namespace LiMarket_V1._0._0.Models
{
    public class MsContext:DbContext
    {
        public MsContext() : base("MSSQL")
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .Map(t => t.MapLeftKey("BookId")
                    .MapRightKey("AuthorId")
                    .ToTable("BookAuthor"));

            modelBuilder.Entity<Genre>()
                .HasMany(c => c.Books)
                .WithOptional(c => c.Genre)
                .HasForeignKey(c => c.GenreId)
                .WillCascadeOnDelete(false);
        }

    }

}