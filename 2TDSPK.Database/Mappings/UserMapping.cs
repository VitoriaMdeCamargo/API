using _2TDSPK.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2TDSPK.Database.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("2TDSPK_USERS");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Email)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasMaxLength(8)
                .IsRequired();                
        }
    }
}
