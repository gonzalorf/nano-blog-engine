﻿using AlphaKids.Domain.Categories;
using AlphaKids.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaKids.Infrastructure.Database.Configurations;

internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id).HasConversion(
            id => id.Value
            , value => new PostId(value));

        builder.HasMany(o => o.Comments)
            .WithOne()
            .HasForeignKey(o => o.PostId);

        builder.HasMany(o => o.Rates)
            .WithOne()
            .HasForeignKey(o => o.PostId);

        builder
            .HasMany(o => o.Categories)
            .WithMany();

        //builder.Property<IReadOnlyList<Category>>("Categories")
        //.HasField("categories")
        //.UsePropertyAccessMode(PropertyAccessMode.Field);

        //builder.Metadata
        //.FindNavigation(nameof(Post.Categories))
        //.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}