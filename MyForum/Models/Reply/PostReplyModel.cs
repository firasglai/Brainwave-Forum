namespace MyForum.Web.Models.Reply
{
    public class PostReplyModel

    {
        public int Id { get; set; }
        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public byte[]? AuthorImageUrl { get; set; }

        public DateTime Created { get; set; }

        public string ReplyContent { get; set; }
        public int PostId { get; set; }

        public bool isAuthorAdmin { get; set; }

    }
}
