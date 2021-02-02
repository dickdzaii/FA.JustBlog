namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Post
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Title can't be empty")]
        public string Title { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        [StringLength(1024)]
        public string PostContent { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        [Timestamp]
        public DateTime? PostedOn { get; set; }

        public bool Modified { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public virtual IList<Tag> Tags { get; set; }
    }
}
