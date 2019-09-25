using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIssueRepro
{
    public class DataContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().ToTable("Assets");
            modelBuilder.Entity<Tag>().ToTable("Tags");
        }
    }
}

public class Asset
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int AssetID { get; set; }
    public string Name { get; set; }
    public virtual List<Tag> Tags { get; set; }

    public Asset()
    {
        Tags = new List<Tag>();
    }
}

public class Tag
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int TagID { get; set; }
    public string Name { get; set; }

    public virtual Asset Asset { get; set; }
}