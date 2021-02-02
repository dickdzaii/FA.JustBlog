namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Class TagRepository to implements ITagRepository's methods.
    /// </summary>
    public class TagRepository : ITagRepository
    {
        private readonly JustBlogContext blogContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagRepository"/> class.
        /// </summary>
        public TagRepository()
        {
            this.blogContext = new JustBlogContext();
        }

        /// <summary>
        /// Add tag to DBContext.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public void AddTag(Tag tag)
        {
            this.blogContext.Tags.Add(tag);
            this.blogContext.SaveChanges();
        }

        /// <summary>
        /// Delete tag by tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public void DeleteTag(Tag tag)
        {
            this.blogContext.SaveChanges();
            this.blogContext.Tags.Remove(tag);
        }

        /// <summary>
        /// Delete tag by tag id.
        /// </summary>
        /// <param name="tagID">Tag id.</param>
        public void DeleteTag(int tagID)
        {
            var tag = this.blogContext.Tags.Find(tagID);
            if (tag != null)
            {
                this.blogContext.Tags.Remove(tag);
                this.blogContext.SaveChanges();
            }
        }

        /// <summary>
        /// Find tag by id.
        /// </summary>
        /// <param name="tagID">Tag id.</param>
        /// <returns>Single tag or null if not found.</returns>
        public Tag Find(int tagID)
        {
            return this.blogContext.Tags.Find(tagID);
        }

        /// <summary>
        /// Get All tags.
        /// </summary>
        /// <returns>List of tags in DBContext.</returns>
        public IList<Tag> GetAllTags()
        {
            return this.blogContext.Tags.ToList();
        }

        /// <summary>
        /// Get tag by url slug.
        /// </summary>
        /// <param name="urlSlug">Tag's url.</param>
        /// <returns>Single tag or null.</returns>
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return this.blogContext.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        /// <summary>
        /// Update tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public void UpdateTag(Tag tag)
        {
            var matchTag = this.blogContext.Tags.Find(tag.ID);
            if (matchTag != null)
            {
                matchTag = tag;
                this.blogContext.SaveChanges();
            }
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
