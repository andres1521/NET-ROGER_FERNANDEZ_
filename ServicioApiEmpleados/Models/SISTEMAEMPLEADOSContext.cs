using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ServicioApiEmpleados.Models
{
    public partial class SISTEMAEMPLEADOSContext : DbContext
    {
        public SISTEMAEMPLEADOSContext()
        {
        }

        public SISTEMAEMPLEADOSContext(DbContextOptions<SISTEMAEMPLEADOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblArea> TblAreas { get; set; }
        public virtual DbSet<TblEmpleado> TblEmpleados { get; set; }
        public virtual DbSet<TblSubarea> TblSubareas { get; set; }
        public virtual DbSet<TblTipoDocumento> TblTipoDocumentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-FKSV53S; Database=SISTEMAEMPLEADOS; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblArea>(entity =>
            {
                entity.HasKey(e => e.NumAreaId)
                    .HasName("PK__TBL_AREA__F0F83F1C3ACBAE48");

                entity.ToTable("TBL_AREA");

                entity.Property(e => e.NumAreaId).HasColumnName("NUM_AREA_ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TblEmpleado>(entity =>
            {
                entity.HasKey(e => e.NumEmpleadoId)
                    .HasName("PK__TBL_EMPL__191D4BAC8682D479");

                entity.ToTable("TBL_EMPLEADO");

                entity.Property(e => e.NumEmpleadoId).HasColumnName("NUM_EMPLEADO_ID");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.NumAreaId).HasColumnName("NUM_AREA_ID");

                entity.Property(e => e.NumDocumento).HasColumnName("NUM_DOCUMENTO");

                entity.Property(e => e.NumSubareaId).HasColumnName("NUM_SUBAREA_ID");

                entity.Property(e => e.NumTipoDocId).HasColumnName("NUM_TIPO_DOC_ID");

                entity.HasOne(d => d.NumArea)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.NumAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TBL_AREA");

                entity.HasOne(d => d.NumSubarea)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.NumSubareaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TBL_EMPLE__NUM_S__5FB337D6");

                entity.HasOne(d => d.NumTipoDoc)
                    .WithMany(p => p.TblEmpleados)
                    .HasForeignKey(d => d.NumTipoDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_TIPO_DOCUMENTO");
            });

            modelBuilder.Entity<TblSubarea>(entity =>
            {
                entity.HasKey(e => e.NumSubareaId)
                    .HasName("PK__TBL_SUBA__F3FCD892D7A716B8");

                entity.ToTable("TBL_SUBAREA");

                entity.Property(e => e.NumSubareaId).HasColumnName("NUM_SUBAREA_ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.NumAreaId).HasColumnName("NUM_AREA_ID");

                entity.HasOne(d => d.NumArea)
                    .WithMany(p => p.TblSubareas)
                    .HasForeignKey(d => d.NumAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TBL_AREA1");
            });

            modelBuilder.Entity<TblTipoDocumento>(entity =>
            {
                entity.HasKey(e => e.NumTipoDocId)
                    .HasName("PK__TBL_TIPO__2FAD7984FE046D63");

                entity.ToTable("TBL_TIPO_DOCUMENTO");

                entity.Property(e => e.NumTipoDocId).HasColumnName("NUM_TIPO_DOC_ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.TipoIdentificacion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_IDENTIFICACION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
