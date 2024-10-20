using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplesmenteUse
{
    public partial class SimplesmenteUseContext : DbContext
    {
        public SimplesmenteUseContext()
        {
        }

        public SimplesmenteUseContext(DbContextOptions<SimplesmenteUseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ObjetoDigitalizado> ObjetoDigitalizados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SimplesmenteUse;User Id=sa;Password=X*qchd&pth;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjetoDigitalizado>(entity =>
            {
                entity.HasKey(e => e.Idobjeto);

                entity.ToTable("objetoDigitalizado");

                entity.Property(e => e.Idobjeto)
                    .ValueGeneratedNever()
                    .HasColumnName("IDOBJETO");

                entity.Property(e => e.Codigotipoobjeto).HasColumnName("CODIGOTIPOOBJETO");

                entity.Property(e => e.Datacriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("DATACRIACAO");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.Idusuariosalvou).HasColumnName("IDUSUARIOSALVOU");

                entity.Property(e => e.Localizacaofisica)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("LOCALIZACAOFISICA");

                entity.Property(e => e.NaoVisualizar).HasColumnName("naoVisualizar");

                entity.Property(e => e.Nomearquivo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NOMEARQUIVO");

                entity.Property(e => e.Objeto)
                    .HasColumnType("image")
                    .HasColumnName("OBJETO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
