
using ChatApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Data.configures
{
    public class configureRoom : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(u => u.Name).IsUnicode(false).IsRequired();
            builder.Property(u => u.Discreption).IsUnicode(false).IsRequired();
            builder.HasMany(r => r.Users).WithOne();
        }
    }
}