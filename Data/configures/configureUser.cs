
using ChatApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApp.Data.configures
{
    public class configureUser : IEntityTypeConfiguration<UserSender>
    {
        public void Configure(EntityTypeBuilder<UserSender> builder)
        {

            builder.Property(u => u.Name).IsUnicode(false).IsRequired();
            builder.Property(u => u.Title).IsUnicode(false).IsRequired();

        }
    }
}