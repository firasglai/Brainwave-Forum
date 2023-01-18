using MyForum.Web.Models.Blog;

namespace MyForum.Web.Models.Post
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId {get; set;}

        public string DatePosted { get; set; }

        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public int RepliesCount { get; set; }
        /*to display blog related data */
        public BlogListingModel Blog { get; set; }




    }
}
