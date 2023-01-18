using MyForum.BL.Entities;


namespace MyForum.BL.Interfaces
{
    public interface IForum
    {
        Blog GetById(int id);
        List<Blog> GetAll();
        List<User> GetAllActiveUsers();
        Task Create(Blog blog);
        Task UpdateTitle(int blogId, string newTitle);
        Task UpdateDescription(int blogId, string newDescription);
        Task Delete(int blogId);

    }
}
