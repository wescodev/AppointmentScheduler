using appointmentapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace appointmentapi.Data.Map;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.CdUser);

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.CreationDate)
            .IsRequired();

        builder.Property(u => u.FlAtivo)
            .IsRequired();

        builder.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.CdPerson)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
