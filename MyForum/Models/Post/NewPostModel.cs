namespace MyForum.Web.Models.Post
{
    public class NewPostModel
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }

        public string AuthorName { get; set; }

        public string BlogImageUrl { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
