using System;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    internal sealed class apDBcontext:DbContext
    {
        public DbSet<Post> Posts  {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source =./Data/AppDb.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder){
                Post[] postsdata = new Post[6];

                for (int i = 1; i <=6; i++)
                {
                    postsdata[i-1] = new Post{  
                        postId = i,
                        Title = $"title post {i}",
                        Content= $"the contnet post {i} this is the contntent"
                    };
                }
            modelBuilder.Entity<Post>().HasData(postsdata);
        }
    }
}