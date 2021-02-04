using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;

namespace FA.JustBlog.UnitTest
{
    [TestClass]
    public class TestCategoryRepository
    {
        private readonly CategoryRepository categoryRepository=new CategoryRepository();
        [TestMethod]
        public void TestGetAllCategory()
        {
            var test = categoryRepository.GetAllCategories();
            Assert.AreEqual(3,test.Count);
        }
        [TestMethod]
        public void TestFindCategory()
        {
            var found = categoryRepository.FindCategory(1);
            var notFound = categoryRepository.FindCategory(4);
            Assert.IsNotNull(found);
            Assert.IsNull(notFound);
        }
        [TestMethod]
        public void TestDeleteCategory()
        {
            categoryRepository.DeleteCategory(2);
            categoryRepository.DeleteCategory(5);
        }
        [TestMethod]
        public void TestAddcategory()
        {
            var validCategory = new Category()
            {
                CategoryName = "Education",
                UrlSlug = "education",
                Description = "education news",
            };
            categoryRepository.CreateCategory(validCategory);
            Assert.AreEqual(4, categoryRepository.GetAllCategories().Count);
        }
    }
}
