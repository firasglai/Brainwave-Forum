
namespace MyForum.BL.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime PublishedDateTime { get; set; }

        public virtual User? User { get; set; }

        public virtual List<PostReply>? Replies { get; set; } 
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}

