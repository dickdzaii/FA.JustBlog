namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Class PostRepository.
    /// </summary>
    public class PostRepository : IPostRepository
    {
        private readonly JustBlogContext blogContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostRepository"/> class.
        /// </summary>
        public PostRepository()
        {
            this.blogContext = new JustBlogContext();
        }

        /// <summary>
        /// Count posts by category.
        /// </summary>
        /// <param name="categoryID">Category id.</param>
        /// <returns>Number of posts that match.</returns>
        public int CountPostByCategory(int categoryID)
        {
            return this.blogContext.Posts.Where(p => p.CategoryID == categoryID).Count();
        }

        /// <summary>
        /// Create post.
        /// </summary>
        /// <param name="post">Post.</param>
        public void CreatePost(Post post)
        {
            this.blogContext.Posts.Add(post);
            this.blogContext.SaveChanges();
        }

        /// <summary>
        /// Delete post by post.
        /// </summary>
        /// <param name="post">Post.</param>
        public void DeletePost(Post post)
        {
            this.blogContext.Posts.Remove(post);
            this.blogContext.SaveChanges();
        }

        /// <summary>
        /// Delete post by post id.
        /// </summary>
        /// <param name="postID">Post id.</param>
        public void DeletePost(int postID)
        {
            var post = this.blogContext.Posts.Find(postID);
            if (post != null)
            {
                this.blogContext.Posts.Remove(post);
                this.blogContext.SaveChanges();
            }
        }

        /// <summary>
        /// Find post by id.
        /// </summary>
        /// <param name="postID">Post id.</param>
        /// <returns>Post or null.</returns>
        public Post FindPost(int postID)
        {
            return this.blogContext.Posts.Find(postID);
        }

        /// <summary>
        /// Find post by year and mont published and url slug.
        /// </summary>
        /// <param name="year">Year published.</param>
        /// <param name="month">Month published.</param>
        /// <param name="urlSlug">Post's url slug.</param>
        /// <returns>Post or null.</returns>
        public Post FindPost(int year, int month, string urlSlug)
        {
            var post = this.blogContext.Posts.
                Where(p => p.PostedOn.Value.Year == year && p.PostedOn.Value.Month == month && p.UrlSlug == urlSlug).FirstOrDefault();
            return post;
        }

        /// <summary>
        /// Get all post.
        /// </summary>
        /// <returns>List of posts.</returns>
        public IList<Post> GetAllPost()
        {
            return this.blogContext.Posts.ToList();
        }

        /// <summary>
        /// Get latest post.
        /// </summary>
        /// <param name="size">Number of posts.</param>
        /// <returns>List of posts.</returns>
        public IList<Post> GetLatestPost(int size)
        {
            return this.blogContext.Posts
                .OrderByDescending(p => p.PostedOn.Value).Take(size).ToList();
        }

        /// <summary>
        /// Get posts by category.
        /// </summary>
        /// <param name="categoryID">Category id.</param>
        /// <returns>List of posts that match.</returns>
        public IList<Post> GetPostByCategory(int categoryID)
        {
            return this.blogContext.Posts.Where(p => p.CategoryID == categoryID).ToList();
        }

        /// <summary>
        /// Get posts by month published.
        /// </summary>
        /// <param name="month">Post's month published.</param>
        /// <returns>List of posts that match.</returns>
        public IList<Post> GetPostByMonth(int month)
        {
            return this.blogContext.Posts.Where(p => p.PostedOn.Value.Month == month).ToList();
        }

        /// <summary>
        /// Get all published posts.
        /// </summary>
        /// <returns>List published posts.</returns>
        public IList<Post> GetPublishedPost()
        {
            return this.blogContext.Posts.Where(p => p.Published).ToList();
        }

        /// <summary>
        /// Get all unpublished posts.
        /// </summary>
        /// <returns>List unpublished posts.</returns>
        public IList<Post> GetUnpublishedPost()
        {
            return this.blogContext.Posts.Where(p => !p.Published).ToList();
        }

        /// <summary>
        /// Update post.
        /// </summary>
        /// <param name="post">Post.</param>
        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Count posts that have the tag.
        /// </summary>
        /// <param name="tag">Tag name.</param>
        /// <returns>Number of posts that match.</returns>
        public int CountPostsForTag(string tag)
        {
            var matchTag = this.blogContext.Tags.FirstOrDefault(t => t.TagName == tag);
            return this.blogContext.Posts.Where(p => p.Tags == matchTag).Count();
        }

        /// <summary>
        /// Get all posts that have the tag.
        /// </summary>
        /// <param name="tag">Tag name.</param>
        /// <returns>List of posts that match.</returns>
        public IList<Post> GetPostsByTag(string tag)
        {
            var matchTag = this.blogContext.Tags.FirstOrDefault(t => t.TagName == tag);
            return this.blogContext.Posts.Where(p => p.Tags == matchTag).ToList();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            this.blogContext.Dispose();
        }
    }
}
