namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JustBlogContext : DbContext
    {
        public JustBlogContext()
            : base("name=JustBlogContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Post>().Map(m =>
            {
            });
        }
    }
}
