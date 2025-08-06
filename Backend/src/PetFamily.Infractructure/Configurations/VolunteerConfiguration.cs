using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infractructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");

        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value)
            )
            .HasColumnName("id");

        builder.Property(v => v.FIO)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("fio");

        builder.Property(v => v.Email)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
            .HasColumnName("email");

        builder.Property(v => v.Description)
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
            .HasColumnName("description");

        builder.Property(v => v.YearsOfExperience)
            .HasColumnName("years_of_experience");

        builder.ComplexProperty(v => v.Phone, pb =>
        {
            pb.Property(pr => pr.Number)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("number");
        });
        
        builder.OwnsMany(v => v.SocialNetworks, sb =>
        {
            sb.ToJson("social_networks");

            sb.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("name");
            
            sb.Property(prop => prop.Url)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("url");
        });

    builder.OwnsMany(v => v.PaymentDetails, pb =>
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

        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}