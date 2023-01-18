using Microsoft.EntityFrameworkCore;
using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.DAL;

namespace MyForum.Web.Services
{
    public class ForumService : IForum
    {
        private readonly  MyForumDbContext _context;

        public ForumService(MyForumDbContext context)
        {
            _context = context;
            
        }

        public Task Create(Blog blog)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int blogId)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            return _context.Blogs.Include(blog => blog.Posts).ToList();

        }

        public List<User> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            var blog = _context.Blogs.Where(b => b.BlogId == id)
                .Include(blog => blog.Posts).ThenInclude(p => p.User)
                .Include(b => b.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                .FirstOrDefault();




            return blog;

                 }              

        public Task UpdateDescription(int blogId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTitle(int blogId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
