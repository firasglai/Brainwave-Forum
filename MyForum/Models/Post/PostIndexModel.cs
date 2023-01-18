using MyForum.Web.Models.Reply;

namespace MyForum.Web.Models.Post
{
    public class PostIndexModel

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }

        public byte[]? AuthorImageUrl { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }

        public List<PostReplyModel> Replies { get; set; }

        

    }
}
