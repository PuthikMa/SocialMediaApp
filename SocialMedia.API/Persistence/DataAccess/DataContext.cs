using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace SocialMedia.API.Persistence.DataAccess
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Photo>(x => x.HasKey(u => u.Id));
            builder.Entity<Comment>(x => x.HasKey(u => u.Id));
            builder.Entity<Photo>(x => x.HasKey(u => u.Id));

            builder.Entity<Comment>()
                .HasOne(a => a.Post)
                .WithMany(u => u.Comments)
                .HasForeignKey(a => a.PostId);

            builder.Entity<Comment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(s => s.UserId);

            builder.Entity<Post>()
                .HasOne(a => a.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(s => s.UserId);

            builder.Entity<Photo>()
                .HasOne(a => a.User)
                .WithMany(m => m.Photos)
                .HasForeignKey(u => u.UserId);

        }

    }
}
