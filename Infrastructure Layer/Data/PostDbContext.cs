using System;
using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Domain_Layer.Entities;

namespace WebApplicationTest.Infrastructure_Layer.Data
{
    public class PostDbContext: DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
