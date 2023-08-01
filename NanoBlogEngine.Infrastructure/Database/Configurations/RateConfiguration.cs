﻿using NanoBlogEngine.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NanoBlogEngine.Infrastructure.Database.Configurations;

internal class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        _ = builder.ToTable("Rates");

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new RateId(value));

        _ = builder.HasOne(c => c.Rater)
            .WithMany()
            .HasForeignKey("RaterId");
    }
}