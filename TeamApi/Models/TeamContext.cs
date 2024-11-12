using Microsoft.EntityFrameworkCore;

namespace TeamApi.Models;

public partial class TeamContext : DbContext
{
    public TeamContext()
    {
    }

    public TeamContext(DbContextOptions<TeamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Data> Data { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=team;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Data>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("data");

            entity.HasIndex(e => e.PlayerId, "PlayerId");

            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.Fault)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Goal)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.InCourt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.OutCourt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.PlayerId).HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Try)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.UpdatedTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Player).WithMany(p => p.Data)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("data_ibfk_1");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("player");

            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime");
            entity.Property(e => e.Height)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasDefaultValueSql("'NULL'");
            entity.Property(e => e.Weight)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
