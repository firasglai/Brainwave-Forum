using MyForum.Web.Models.Post;

namespace MyForum.Web.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingModel>LatestPosts { get; set; }

    }
}
