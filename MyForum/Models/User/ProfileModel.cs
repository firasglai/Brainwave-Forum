namespace MyForum.Web.Models.User
{
    public class ProfileModel
    {

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime MemberSince { get; set; }
        public bool Confirmed { get; set; }

        //the byte to be converted in the controller or service
        public string ProfileImageUrl { get; set; }

        public IFormFile ImageUpload { get; set; } 

        public bool IsAdmin { get; set; }


    }
}
