using Microsoft.AspNetCore.Mvc;
using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.Web.Models.Post;
using MyForum.Web.Models.Reply;
using System.Threading.Tasks;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;

namespace MyForum.Web.Controllers
{
    public class PostController : Controller
    {
        private static UserManager<User> _userManager;
        private readonly IPost _postService;
        private readonly IForum _forumService;

        public PostController(IPost postService, IForum forumService , UserManager<User> userManager)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
        }

        public IActionResult Index( int id )
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);
            var model = new PostIndexModel
            {
                Id = post.PostId,
                Title = post.Title,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorImageUrl =post.User.ProfilePicture,
                Created = DateTime.Now,
                PostContent = post.Content,
                Replies = replies

            };
            return View(model);
        }

        public IActionResult Create(int id)
        {
            var blog = _forumService.GetById(id);

            var model = new NewPostModel
            {

                BlogId = blog.BlogId,
                BlogName = blog.BlogName,
                BlogImageUrl = blog.ImageUrl,
                AuthorName = User.Identity.Name

            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> AddPost (NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);

            await _postService.Add(post);
            return RedirectToAction("Index", "Post", new {id = post.PostId });
        }

        private Post BuildPost(NewPostModel model, User user)
        {
            var blog = _forumService.GetById(model.BlogId);
            return new Post
            {
                Title = model.Title,
                Content=model.Content,
                PublishedDateTime =DateTime.Now,
                User = user,
                Blog=blog
              
            };
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply>? replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id=reply.Id,
                AuthorName=reply.User.UserName,
                AuthorId=reply.User.Id,
                AuthorImageUrl=reply.User.ProfilePicture,
                Created=reply.Created,
                ReplyContent=reply.Content

            });
        }
    }
}
