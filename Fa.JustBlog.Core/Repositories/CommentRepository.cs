namespace FA.JustBlog.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FA.JustBlog.Core.Models;

    /// <summary>
    /// Comment Repository.
    /// </summary>
    public class CommentRepository : ICommentRepository
    {
        private JustBlogContext blogContext;

        /// <summary>
        /// Add new comment.
        /// </summary>
        /// <param name="comment">Comment.</param>
        public void AddComment(Comment comment)
        {
            this.blogContext.Comments.Add(comment);
            this.blogContext.SaveChanges();
        }

        /// <summary>
        /// Add comment by attributes.
        /// </summary>
        /// <param name="postID">Post id.</param>
        /// <param name="commentName">Comment name.</param>
        /// <param name="commentEmail">Comment email.</param>
        /// <param name="commentTitle">Comment header.</param>
        /// <param name="commentBody">Comment text.</param>
        public void AddComment(int postID, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var newComment = new Comment();
            newComment.PostID = postID;
            newComment.Name = commentName;
            newComment.Email = commentEmail;
            newComment.CommentHeader = commentTitle;
            newComment.CommentText = commentBody;
            newComment.CommentTime = DateTime.Now;
            this.blogContext.Comments.Add(newComment);
            this.blogContext.SaveChanges();
        }

        /// <summary>
        /// Delete comment by comment.
        /// </summary>
        /// <param name="comment">Comment.</param>
        public void DeleteComment(Comment comment)
        {
            this.blogContext.Comments.Remove(comment);
            this.blogContext.SaveChanges();
        }

        /// <summary>
        /// Delete comment by id.
        /// </summary>
        /// <param name="commentID">Comment id.</param>
        public void DeleteComment(int commentID)
        {
            var comment = this.blogContext.Comments.Find(commentID);
            if (comment != null)
            {
                this.blogContext.Comments.Remove(comment);
                this.blogContext.SaveChanges();
            }
        }

        /// <summary>
        /// Find comment by id.
        /// </summary>
        /// <param name="id">Comment id.</param>
        /// <returns>Comment or null.</returns>
        public Comment Find(int id)
        {
            return this.blogContext.Comments.Find(id);
        }

        /// <summary>
        /// Get all comments.
        /// </summary>
        /// <returns>All comments.</returns>
        public IList<Comment> GetAllComments()
        {
            return this.blogContext.Comments.ToList();
        }

        /// <summary>
        /// Get all post's comments by post id.
        /// </summary>
        /// <param name="postID">Post.</param>
        /// <returns>List of comments.</returns>
        public IList<Comment> GetCommentsForPost(int postID)
        {
            var comments = this.blogContext.Comments.Where(c => c.PostID == postID).ToList();
            return comments;
        }

        /// <summary>
        /// Get all post's comments by post.
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>List of comments.</returns>
        public IList<Comment> GetCommentsForPost(Post post)
        {
            var comments = this.blogContext.Comments.Where(c => c.Post == post).ToList();
            return comments;
        }

        /// <summary>
        /// Update comment.
        /// </summary>
        /// <param name="comment">comment.</param>
        public void UpdateComment(Comment comment)
        {
            var matchComment = this.blogContext.Comments.Find(comment.ID);
            if (matchComment != null)
            {
                matchComment = comment;
                this.blogContext.SaveChanges();
            }
        }
    }
}
