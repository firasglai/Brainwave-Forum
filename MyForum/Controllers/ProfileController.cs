using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyForum.BL.Entities;
using MyForum.BL.Interfaces;
using MyForum.Web.Models.User;

namespace MyForum.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUser _userservice;
       
   
        public ProfileController(UserManager<User> userManager, IUser userService)
        {
            _userManager = userManager;
            _userservice = userService;
            
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Detail(string id)
        {
            var user = _userservice.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;       
            var model = new ProfileModel()
  
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Confirmed =user.EmailConfirmed,
                IsAdmin = userRoles.Contains("Moderator")
                
            };
            return View(model);
        }
        
    }
}
