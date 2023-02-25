using Microsoft.AspNetCore.Identity;
namespace MyForum.BL.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? UsernameChangeLimit { get; set; } = 10;
        // maybe set it to string
        public byte[]? ProfilePicture { get; set; }




    }
}
