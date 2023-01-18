namespace MyForum.BL.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string BlogName { get; set; }

        public string BlogDescription { get; set; }

        public DateTime Created { get; set; }

        public string ImageUrl { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}
