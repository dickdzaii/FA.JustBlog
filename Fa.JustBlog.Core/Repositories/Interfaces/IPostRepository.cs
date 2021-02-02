using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{
    public interface IPostRepository
    {
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        void DeletePost(int postID);
        Post FindPost(int postID);
        Post FindPost(int year,int month,string urlSlug);
        IList<Post> GetAllPost();
        IList<Post> GetPublishedPost();
        IList<Post> GetUnpublishedPost();
        IList<Post> GetPostByMonth(int month);
        IList<Post> GetLatestPost(int size);
        int CountPostByCategory(int categoryID);
        IList<Post> GetPostByCategory(int categoryID);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);
    }
}
