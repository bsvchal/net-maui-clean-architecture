using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureMaui.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; } 
        public DbSet<Song> Songs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Musician>()
                .HasKey(ms => ms.Id);
            modelBuilder.Entity<Song>()
                .HasKey(sg => sg.Id);

            modelBuilder.Entity<Musician>()
                .HasMany(ms => ms.Songs)
                .WithOne(sg => sg.Musician)
                .HasForeignKey(sg => sg.MusicianId);

            modelBuilder.Entity<Song>()
                .HasOne(sg => sg.Musician)
                .WithMany(ms => ms.Songs)
                .HasForeignKey(sg => sg.MusicianId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
