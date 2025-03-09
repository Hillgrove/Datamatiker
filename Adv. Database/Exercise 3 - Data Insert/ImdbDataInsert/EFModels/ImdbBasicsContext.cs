using Microsoft.EntityFrameworkCore;

namespace ImdbDataInsert.EFModels;

public partial class ImdbBasicsContext : DbContext
{
    public ImdbBasicsContext()
    {
    }

    public ImdbBasicsContext(DbContextOptions<ImdbBasicsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<TitleGenre> TitleGenres { get; set; }

    public virtual DbSet<TitleType> TitleTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=Hilldesk;Database=ImdbBasics;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.HasIndex(e => e.Name, "UQ_Genre_Name").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.Tconst);

            entity.ToTable("Title");

            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OriginalTitle).HasMaxLength(255);
            entity.Property(e => e.PrimaryTitle).HasMaxLength(255);
            entity.Property(e => e.TitleTypeId).HasColumnName("TitleTypeID");
        });

        modelBuilder.Entity<TitleGenre>(entity =>
        {
            entity.HasKey(e => new { e.Tconst, e.GenreId });

            entity.ToTable("TitleGenre");

            entity.Property(e => e.Tconst)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
        });

        modelBuilder.Entity<TitleType>(entity =>
        {
            entity.ToTable("TitleType");

            entity.HasIndex(e => e.Name, "UQ_TitleType_Name").IsUnique();

            entity.Property(e => e.TitleTypeId).HasColumnName("TitleTypeID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
