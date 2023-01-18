using Microsoft.AspNetCore.Mvc;
using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.Web.Models.Post;
using MyForum.Web.Models.Reply;

namespace MyForum.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;

        public PostController(IPost postService)
        {
            _postService = postService;
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

        private List<PostReplyModel> BuildPostReplies(List<PostReply>? replies)
        {
            return (List<PostReplyModel>)replies.Select(reply => new PostReplyModel
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
