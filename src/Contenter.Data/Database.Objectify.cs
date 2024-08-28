using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;
public partial class Database
{
  public DbSet<Contenter.Models.Objectify.Scope> Scopes => this.Set<Contenter.Models.Objectify.Scope>();
  public DbSet<Contenter.Models.Objectify.ThingDefinition> ThingDefinitions => this.Set<Contenter.Models.Objectify.ThingDefinition>();
  public DbSet<Contenter.Models.Objectify.RelationDefinition> RelationDefinitions => this.Set<Contenter.Models.Objectify.RelationDefinition>();
  public DbSet<Contenter.Models.Objectify.Thing> Things => this.Set<Contenter.Models.Objectify.Thing>();
  
  protected void ConfigureObjectify(ModelBuilder mb)
  {
    mb.Entity<Contenter.Models.Objectify.Scope>(scopes => {
      scopes.ToTable("OScopes");
    });
    mb.Entity<Contenter.Models.Objectify.ThingDefinition>(thingdefinitions => {
      thingdefinitions.ToTable("OThingDefinitions");
      thingdefinitions.HasMany(item => item.RelationDefinitionsFrom).WithOne(item => item.From);
      thingdefinitions.HasMany(item => item.RelationDefinitionsTo).WithOne(item => item.To);
    });
    mb.Entity<Contenter.Models.Objectify.RelationDefinition>(relationDefinitions => {
      relationDefinitions.ToTable("ORelationDefinitions");
    });
    mb.Entity<Contenter.Models.Objectify.Thing>(things => {
      things.ToTable("OThings");
      things.Property(item => item.Links).HasDefaultValue(new List<string>());
      things.HasMany(item => item.RelationsFrom).WithOne(item => item.From);
      things.HasMany(item => item.RelationsTo).WithOne(item => item.To);
    });
    mb.Entity<Contenter.Models.Objectify.Relation>(relations => {
      relations.ToTable("ORelations");

    });
  }
}
