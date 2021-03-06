﻿namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    public interface ICategoryRepository
    {
        Category FindCategory(int categoryID);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int categoryID);

        IList<Category> GetAllCategories();
    }
}
