using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Infractructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");
        
        builder.Property(b => b.Id)
            .HasConversion(
                id => id.Value, 
                value => SpeciesId.Create(value)
            )
            .HasColumnName("id");
        
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("name");
        
        builder.HasMany(v => v.Breeds)
            .WithOne()
            .HasForeignKey("breed_id");
    }
}