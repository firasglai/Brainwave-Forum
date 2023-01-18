using MyForum.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.BL.Interfaces
{
    public interface IPost
    {

        Post GetById(int id);
        List<Post> GetAll();
        List<Post> GetFilteredPosts(string searchQuery);
        List<Post> GetPostByBlog(int id);

       IEnumerable<Post> GetLatestPosts(int x);

        Task Add(Post post);
        Task Delete(int id);
      //  Task AddReply(PostReply reply);
        Task EditPostContent(int id, string newContent);

      
        


    }
}
