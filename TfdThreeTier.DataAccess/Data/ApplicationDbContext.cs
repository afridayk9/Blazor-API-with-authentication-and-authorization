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
    public DbSet<Pattern> Patterns { get; set; }
    public DbSet<CharacterComponent> CharacterComponents { get; set; }
    public DbSet<ComponentMaterial> ComponentMaterials { get; set; }
    public DbSet<MaterialPattern> MaterialPatterns { get; set; }
    public DbSet<ComponentPattern> ComponentPatterns { get; set; }
    public DbSet<CharacterPattern> CharacterPatterns { get; set; }

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

        modelBuilder.Entity<MaterialPattern>()
            .HasKey(mp => new { mp.MaterialId, mp.PatternId });

        modelBuilder.Entity<MaterialPattern>()
            .HasOne(mp => mp.Material)
            .WithMany(m => m.MaterialPatterns)
            .HasForeignKey(mp => mp.MaterialId);

        modelBuilder.Entity<MaterialPattern>()
            .HasOne(mp => mp.Pattern)
            .WithMany(p => p.MaterialPatterns)
            .HasForeignKey(mp => mp.PatternId);

        modelBuilder.Entity<ComponentPattern>()
            .HasKey(cp => new { cp.ComponentId, cp.PatternId });

        modelBuilder.Entity<ComponentPattern>()
            .HasOne(cp => cp.Component)
            .WithMany(c => c.ComponentPatterns)
            .HasForeignKey(cp => cp.ComponentId);

        modelBuilder.Entity<ComponentPattern>()
            .HasOne(cp => cp.Pattern)
            .WithMany(p => p.ComponentPatterns)
            .HasForeignKey(cp => cp.PatternId);

        modelBuilder.Entity<CharacterPattern>()
            .HasKey(cp => new { cp.CharacterId, cp.PatternId });

        modelBuilder.Entity<CharacterPattern>()
            .HasOne(cp => cp.Character)
            .WithMany(c => c.CharacterPatterns)
            .HasForeignKey(cp => cp.CharacterId);

        modelBuilder.Entity<CharacterPattern>()
            .HasOne(cp => cp.Pattern)
            .WithMany(p => p.CharacterPatterns)
            .HasForeignKey(cp => cp.PatternId);

        modelBuilder.Entity<CharacterPattern>()
            .Property(cp => cp.MaterialDropChance)
            .IsRequired();
    }
}