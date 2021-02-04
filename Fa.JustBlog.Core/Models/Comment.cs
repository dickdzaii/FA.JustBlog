namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Comment entity.
    /// </summary>
    public class Comment
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int PostID { get; set; }

        public Post Post { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public DateTime? CommentTime { get; set; }
    }
}
