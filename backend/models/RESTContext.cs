using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace REST.models
{
    public partial class RESTContext : DbContext
    {
        public virtual DbSet<Xss> Xss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=REST;Username=postgres;Password=phAIsl5Pw8X9AXUfnmqH");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Xss>(entity =>
            {
                entity.ToTable("xss");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Thevalue)
                    .HasColumnName("thevalue")
                    .HasColumnType("varchar");
            });
        }
    }
}
