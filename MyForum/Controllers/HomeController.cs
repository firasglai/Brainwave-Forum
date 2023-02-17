using Microsoft.AspNetCore.Mvc;
using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.Models;
using MyForum.Web.Models.Blog;
using MyForum.Web.Models.Home;
using MyForum.Web.Models.Post;
using System.Diagnostics;

namespace MyForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPost _postService;

        public HomeController(ILogger<HomeController> logger , IPost postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public IActionResult Index()

        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);
       
            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.PostId,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                DatePosted = post.PublishedDateTime.ToString(),
                RepliesCount = post.Replies.Count(),
                Blog = BuildBlogListingForPost(post)


            }); ;
            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery=""
            };
        }

        private BlogListingModel BuildBlogListingForPost(Post post)
        {
            var blog = post.Blog;
            return new BlogListingModel
            {
                Id = blog.BlogId,
                Name = blog.BlogName,
                Description = blog.BlogDescription,
                ImageUrl=blog.ImageUrl
                
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}