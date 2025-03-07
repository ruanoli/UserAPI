using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Entities;

namespace UserAPI.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID");


            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(x => x.RegisterDate)
                .HasColumnName("REGISTER_DATE")
                .IsRequired();

            builder.Property(x => x.LastUpdateDate)
                .HasColumnName("LAST_UPDATE")
                .IsRequired();
        }
    }
}
