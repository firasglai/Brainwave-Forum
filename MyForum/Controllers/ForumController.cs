using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyForum.BL.Entities;
using MyForum.DAL;
using MyForum.Web.Models.Blog;
using System.Linq.Expressions;
using System.Linq;
using MyForum.BL.Interfaces;
using MyForum.Web.Models.Post;

namespace MyForum.Web.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;

        //private readonly IPost _postService;

        //, IPost postService
        public ForumController(IForum forumService )
        {
            _forumService = forumService;
           // _postService = postService;
        }


        /**/

        public IActionResult Index()
        {
          
            var blogs = _forumService.GetAll()
                .Select( blog => new BlogListingModel  {
                    Id =blog.BlogId,
                    Name =blog.BlogName,
                    Description =blog.BlogDescription
            });

            var model = new BlogIndexModel
            {
                BlogList = blogs.ToList()
            };
            
                return View(model);
        }
        public IActionResult Topic (int id)
        {
            var blog = _forumService.GetById(id);
            var posts = blog.Posts;

            var postList = posts.Select(post => new PostListingModel
            { 
                Id = post.PostId,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                Title = post.Title,
                DatePosted = post.PublishedDateTime.ToString(),
                RepliesCount = post.Replies.Count(),
                Blog = BuildBlogListing(post) 
            });

            var model = new BlogPostModel
            {
                Posts = postList.ToList(),
                Blog = BuildBlogListing(blog)

            };
            
            return View(model);
        }

        private BlogListingModel BuildBlogListing(Post post)
        {
          var blog = post.Blog;
            return BuildBlogListing(blog);
        }

        private BlogListingModel BuildBlogListing(Blog blog)
        {
            return new BlogListingModel
            {
                Id = blog.BlogId,
                Name = blog.BlogName,
                Description = blog.BlogDescription
            };
        }
    }
}
