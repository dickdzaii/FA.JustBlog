namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Initializer.
    /// </summary>
    public class JustBlogInitializer : DropCreateDatabaseIfModelChanges<JustBlogContext>
    {
        /// <summary>
        /// Seed data.
        /// </summary>
        /// <param name="context">context.</param>
        protected override void Seed(JustBlogContext context)
        {
            base.Seed(context);
            //// add Category:
            Category news = new Category()
            {
                CategoryName = "News",
                UrlSlug = "news",
                Description = "north east west south",
            };
            Category sports = new Category()
            {
                CategoryName = "Sport",
                UrlSlug = "sports",
                Description = "sport news",
            };
            Category technology = new Category()
            {
                CategoryName = "Technology",
                UrlSlug = "technology",
                Description = "!@#$%^&*(",
            };
            context.Categories.AddRange(new List<Category> { news, sports, technology });
            Post postOne = new Post()
            {
                Title = "This is the title",
                ShortDescription = "cdscsdkcsdhc",
                PostContent = @"this is the content",
                UrlSlug = "post-one",
                Published = true,
                PostedOn = new DateTime(2019, 08, 28, 07, 56, 42),
                Modified = false,
                CategoryID = 1,
            };
            Post postTwo = new Post()
            {
                Title = "Ronaldo retired",
                ShortDescription = "cdscsdkcsdhc",
                PostContent = @"cdcascascascasc
                                ascascascsacacascc",
                UrlSlug = "ronaldo-retired",
                Published = false,
                Modified = false,
                CategoryID = 2,
            };
            Post postThree = new Post()
            {
                Title = "Jeff Bezos leave Amazon",
                ShortDescription = "cdscsdkcsdhc",
                PostContent = @"cdhcdhcdhchdhcdcdnc",
                UrlSlug = "jeff-bezos-leave-amazon",
                Published = true,
                PostedOn = new DateTime(2021, 2, 4, 4, 11, 00),
                Modified = false,
                CategoryID = 3,
            };
            context.Posts.AddRange(new List<Post> { postOne, postTwo, postThree });
            Tag football = new Tag()
            {
                TagName = "football",
                UrlSlug = "football",
                Count = 6,
                Posts = new List<Post> { postThree, postTwo },
            };
            Tag abc = new Tag()
            {
                TagName = "abc",
                UrlSlug = "abc",
                Count = 6,
                Posts = new List<Post> { postOne, postTwo },
            };
            Tag ascasch = new Tag()
            {
                TagName = "ascasch",
                UrlSlug = "ascasch",
                Count = 6,
                Posts = new List<Post> { postTwo },
            };
            context.Tags.AddRange(new List<Tag> { football, ascasch, abc });
            context.SaveChanges();
        }
    }
}
