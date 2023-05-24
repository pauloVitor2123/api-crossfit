﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class ProfileMap : BaseEntityMap<ProfileModel>
    {

        public override void Configure(EntityTypeBuilder<ProfileModel> builder)
        {
            builder.HasKey(x => x.IdProfile);
            builder.Property(x => x.IdProfile).HasColumnName("id_profile").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(x => x.NormalizedName).IsRequired().HasMaxLength(255).HasColumnName("normalized_name");
            builder.Property(x => x.Active).IsRequired().HasColumnName("active").HasDefaultValue(true);
            base.Configure(builder);
        }
    }
}
