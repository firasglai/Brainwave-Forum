using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;


namespace MyForum.BL.Entities
{
    public class PostReply
    {
        
        public int Id { get; set; }
        public string? Content { get; set; }

        public DateTime Created { get; set; }  

        public virtual User? User { get; set; }

        public virtual Post? Post { get; set; }

    }
}
