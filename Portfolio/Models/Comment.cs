using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public virtual Post Posts { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
