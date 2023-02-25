using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.DAL;

namespace MyForum.Web.Services
{
    public class UserService : IUser
    {

        private readonly MyForumDbContext _context;

        public UserService(MyForumDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(string id)
        {
         return  GetAll().FirstOrDefault(user => user.Id == id);
        }

        public Task SetProfileImage(string id, Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
