using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoProspectos.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CatStatus> CatStatuses { get; set; }
        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Prospecto> Prospectos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Mexico.1252");

            modelBuilder.Entity<CatStatus>(entity =>
            {
                entity.HasKey(e => e.IdEstatus)
                    .HasName("cat_status_pkey");

                entity.ToTable("cat_status");

                entity.Property(e => e.IdEstatus)
                    .ValueGeneratedNever()
                    .HasColumnName("id_estatus");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento)
                    .HasName("documentos_pkey");

                entity.ToTable("documentos");

                entity.Property(e => e.IdDocumento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_documento");

                entity.Property(e => e.IdProspecto).HasColumnName("id_prospecto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Ruta)
                    .HasMaxLength(300)
                    .HasColumnName("ruta");

                entity.HasOne(d => d.IdProspectoNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdProspecto)
                    .HasConstraintName("documentos_id_prospecto_fkey");
            });

            modelBuilder.Entity<Prospecto>(entity =>
            {
                entity.HasKey(e => e.IdProspecto)
                    .HasName("prospectos_pkey");

                entity.ToTable("prospectos");

                entity.Property(e => e.IdProspecto)
                    .HasColumnName("id_prospecto")
                    .HasDefaultValueSql("nextval('idporespectoseq'::regclass)");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("calle");

                entity.Property(e => e.Colonia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("colonia");

                entity.Property(e => e.Cp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cp");

                entity.Property(e => e.IdEstatus).HasColumnName("id_estatus");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nombre");

                entity.Property(e => e.Observación)
                    .HasMaxLength(400)
                    .HasColumnName("observación");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("rfc");

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Prospectos)
                    .HasForeignKey(d => d.IdEstatus)
                    .HasConstraintName("prospectos_id_estatus_fkey");
            });

            modelBuilder.HasSequence("idporespectoseq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
