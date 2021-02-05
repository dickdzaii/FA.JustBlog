namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Class CategoryRepository.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JustBlogContext blogContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        public CategoryRepository()
        {
            this.blogContext = new JustBlogContext();
        }

        /// <summary>
        /// Create category.
        /// </summary>
        /// <param name="category">Category.</param>
        public void CreateCategory(Category category)
        {
            this.blogContext.Categories.Add(category);
            this.blogContext.SaveChanges();
        }

        /// <summary>
        /// Delete category.
        /// </summary>
        /// <param name="categoryID">Category id.</param>
        public void DeleteCategory(int categoryID)
        {
            var category = this.blogContext.Categories.Find(categoryID);
            if (category != null)
            {
                this.blogContext.Categories.Remove(category);
                this.blogContext.SaveChanges();
            }
        }

        /// <summary>
        /// Find category.
        /// </summary>
        /// <param name="categoryID">Category id.</param>
        /// <returns>Category.</returns>
        public Category FindCategory(int categoryID)
        {
            var category = this.blogContext.Categories.Find(categoryID);
            return category;
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>List of categories.</returns>
        public IList<Category> GetAllCategories()
        {
            return this.blogContext.Categories.ToList();
        }

        /// <summary>
        /// Update category.
        /// </summary>
        /// <param name="category">Category.</param>
        public void UpdateCategory(Category category)
        {
            var targetCategory = this.blogContext.Categories.Find(category.ID);
            targetCategory = category;
            this.blogContext.SaveChanges();
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
