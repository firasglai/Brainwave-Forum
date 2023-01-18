using Microsoft.EntityFrameworkCore;
using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.DAL;
using System.Linq;

namespace MyForum.Web.Services
{
    public class PostService : IPost
    {
        private readonly MyForumDbContext _context;

        public PostService(MyForumDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }   

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
          var posts = _context.Posts
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Blog);
            return posts.ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.PostId == id)
                .Include(post => post.User)
                .Include(post => post.Replies).ThenInclude(reply => reply.User)
                .Include(post => post.Blog)
                .First();
                } 
        public List<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPosts(int x)
        {
            return GetAll().OrderByDescending(post => post.PublishedDateTime).Take(x);
        }

        public List<Post> GetPostByBlog(int id)
        {
            return  _context.Blogs.Where
                (x => x.BlogId == id).First()
                .Posts;
        }
    }
}
