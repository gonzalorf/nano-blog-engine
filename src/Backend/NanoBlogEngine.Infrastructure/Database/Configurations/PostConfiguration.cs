﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NanoBlogEngine.Domain.Posts;

namespace NanoBlogEngine.Infrastructure.Database.Configurations;

internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        _ = builder.ToTable("Posts", SchemaNames.Blog);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id).HasConversion(
            id => id.Value
            , value => new PostId(value));

        _ = builder
            .HasMany(o => o.Categories)
            .WithMany();

    }
}
