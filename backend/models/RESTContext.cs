using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using REST.models;

namespace REST.models
{
    public partial class RESTContext : DbContext
    {
        public virtual DbSet<Creds> Creds { get; set; }

        public RESTContext(DbContextOptions<RESTContext> Options) : base (Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Creds>(entity =>
            {
                entity.ToTable("creds");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Client)
                    .HasColumnName("client")
                    .HasColumnType("varchar")
                    .HasMaxLength(25);

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("varchar")
                    .HasMaxLength(500);
            });
        }
    }
}