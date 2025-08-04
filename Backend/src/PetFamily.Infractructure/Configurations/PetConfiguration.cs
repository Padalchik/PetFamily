using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Infractructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.Property(p => p.Id)
            .HasConversion(
                    id => id.Value, 
                    value => PetId.Create(value)
                );
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(p => p.Description)
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.OwnsOne(p => p.TypeInfo, ti =>
        {
            ti.Property(t => t.SpeciesId)
                .IsRequired();

            ti.Property(t => t.BreedId)
                .IsRequired();

            ti.Property(t => t.Color)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        });
        
        builder.OwnsOne(p => p.HealthInfo, hi =>
        {
            hi.ToJson();
        });
    }
}