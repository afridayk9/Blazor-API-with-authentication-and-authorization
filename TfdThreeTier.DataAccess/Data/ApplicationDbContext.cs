using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.DataAccess.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<CharacterComponent> CharacterComponents { get; set; }
    public DbSet<ComponentMaterial> ComponentMaterials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CharacterComponent>()
            .HasKey(cc => new { cc.CharacterId, cc.ComponentId });

        modelBuilder.Entity<CharacterComponent>()
            .HasOne(cc => cc.Character)
            .WithMany(c => c.CharacterComponents)
            .HasForeignKey(cc => cc.CharacterId);

        modelBuilder.Entity<CharacterComponent>()
            .HasOne(cc => cc.Component)
            .WithMany(c => c.CharacterComponents)
            .HasForeignKey(cc => cc.ComponentId);

        modelBuilder.Entity<ComponentMaterial>()
            .HasKey(cm => new { cm.ComponentId, cm.MaterialId });

        modelBuilder.Entity<ComponentMaterial>()
            .HasOne(cm => cm.Component)
            .WithMany(c => c.ComponentMaterials)
            .HasForeignKey(cm => cm.ComponentId);

        modelBuilder.Entity<ComponentMaterial>()
            .HasOne(cm => cm.Material)
            .WithMany(m => m.ComponentMaterials)
            .HasForeignKey(cm => cm.MaterialId);
    }
}
