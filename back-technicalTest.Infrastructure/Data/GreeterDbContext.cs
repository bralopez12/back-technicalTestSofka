using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace back_technicalTest.Infrastructure.Data
{
    public partial class GreeterDbContext : DbContext
    {
        public GreeterDbContext(DbContextOptions<GreeterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Idioms> Idioms { get; set; }
        public virtual DbSet<ResponsesGreeter> ResponsesGreeter { get; set; }
        public virtual DbSet<ResponsesType> ResponsesType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Idioms>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.IdiomName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ResponsesGreeter>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.Idiom })
                    .HasName("PK_CodeIdiom");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Response)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdiomNavigation)
                    .WithMany(p => p.ResponsesGreeter)
                    .HasForeignKey(d => d.Idiom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResponsesGreeter_Idioms");
            });


            modelBuilder.Entity<ResponsesType>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
