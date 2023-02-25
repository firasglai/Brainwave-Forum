using MyForum.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.BL.Interfaces
{
    public interface IUser
    {
        User GetById(string id);
        IEnumerable<User> GetAll();

        Task SetProfileImage(string id, Uri uri);

        
    }
}
