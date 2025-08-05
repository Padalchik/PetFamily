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
                )
            .HasColumnName("id");
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("name");
        
        builder.Property(p => p.Description)
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
            .HasColumnName("description");

        builder.ComplexProperty(p => p.TypeInfo, tb =>
        {
            tb.Property(t => t.SpeciesId)
                .IsRequired()
                .HasColumnName("id_species");

            tb.Property(t => t.BreedId)
                .IsRequired()
                .HasColumnName("id_breed");

            tb.Property(t => t.Color)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("color");
        });
        
        builder.ComplexProperty(p => p.HealthInfo, hb =>
        {
            hb.Property(prop => prop.Sex)
                .HasConversion<string>()
                .HasColumnName("sex");
            
            hb.Property(prop => prop.WeightKg)
                .HasColumnName("weight_kg");
            
            hb.Property(prop => prop.HeightCm)
                .HasColumnName("height_cm");
            
            hb.Property(prop => prop.BirthDate)
                .IsRequired()
                .HasColumnName("birth_date");
            
            hb.Property(prop => prop.IsNeutered)
                .HasColumnName("is_neutered");
           
            hb.Property(prop => prop.IsVaccinated)
                .HasColumnName("is_vaccinated");
            
            hb.Property(prop => prop.Description)
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("description");
        });

        builder.ComplexProperty(p => p.Address, pi =>
        {
            pi.Property(pr => pr.City)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("city");
            
            pi.Property(pr => pr.Street)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("street");
            
            pi.Property(pr => pr.HouseNumber)
                .IsRequired(false)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("house_number");
        });

        builder.ComplexProperty(p => p.PhoneNumber, pi =>
        {
            pi.Property(pr => pr.Number)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("number");
        });
        
        builder.Property(prop => prop.HelpStatus)
            .HasConversion<string>()
            .HasColumnName("help_status");

        builder.OwnsMany(p => p.PaymentDetails, pb =>
        {
            pb.ToJson("payment_details");
            
            pb.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("name");
            
            pb.Property(prop => prop.Description)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("description");
            
            pb.Property(prop => prop.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("value");
        });
        
        builder.Property(prop => prop.CreateDate)
            .IsRequired()
            .HasColumnName("create_date");
    }
}