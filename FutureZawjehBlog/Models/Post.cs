using System.ComponentModel.DataAnnotations;

namespace FutureZawjehBlog.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public string? UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTimeOffset TimeOfPost { get; set; }

        public DateTimeOffset? LastModi {  get; set; }
    }
}
