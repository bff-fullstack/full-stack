using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace REST.models
{
    public partial class RESTContext : DbContext
    {
        public virtual DbSet<Xss> Xss { get; set; }

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
