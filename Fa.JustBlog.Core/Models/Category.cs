namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Category
    {
        [Key]
        public int ID { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Category name can't be empty.")]
        public string CategoryName { get; set; }

        [StringLength(255)]
        public string UrlSlug { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
