﻿using NanoBlogEngine.Domain.Categories;
using NanoBlogEngine.Domain.Posts;
using NanoBlogEngine.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace NanoBlogEngine.Infrastructure.Database;

public interface IApplicationDbContext
{
    DbSet<Post> Posts { get; set; }

    DbSet<Category> Categories { get; set; }

    DbSet<User> Users { get; set; }
}