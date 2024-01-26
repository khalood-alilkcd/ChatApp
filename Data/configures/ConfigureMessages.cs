
using ChatApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatApp.Data.configure
{
    public class ConfigureMessages : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            var utcConverter = new ValueConverter<DateTime, DateTime>(
                toDb => toDb,
                fromDb =>
                    DateTime.SpecifyKind(fromDb, DateTimeKind.Utc)
            );
            builder.Property(m => m.WriteMassge).IsUnicode(false).HasMaxLength(500).IsRequired();
            builder.HasKey("MessageId");

            builder.Property(m => m.TOfMsg).HasConversion(
                sendto => sendto.ToString(),
                comingFrom => (TypeOfMsg)Enum.Parse(typeof(TypeOfMsg), comingFrom)
            );

            builder.Property(m => m.DateOfMsg).HasConversion(utcConverter);

            builder.HasOne(p => p.Sender).WithMany().HasForeignKey(p => p.SenderId);

        }
    }
}