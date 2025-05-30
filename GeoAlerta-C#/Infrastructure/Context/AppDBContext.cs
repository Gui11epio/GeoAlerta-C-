using GeoAlerta_C_.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeoAlerta_C_.Infrastructure.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Alertas> Alertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIO");
            modelBuilder.Entity<Endereco>().ToTable("TB_ENDERECO");
            modelBuilder.Entity<Alertas>().ToTable("TB_ALERTAS");


            //1:1 Usuario - Endereco
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Endereco)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Endereco>(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            //N:1 Alertas - Usuario
            modelBuilder.Entity<Alertas>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Alertas)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            //N:1 Alertas - Endereco
            modelBuilder.Entity<Alertas>()
                .HasOne(a => a.Endereco)
                .WithMany()
                .HasForeignKey(a => a.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);








        }
    }
}
