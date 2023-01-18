using MyForum.Web.Models.Post;

namespace MyForum.Web.Models.Blog
{
    public class BlogPostModel
    {
        public BlogListingModel Blog { get; set; }
        public List<PostListingModel> Posts { get; set; }


    }
}
