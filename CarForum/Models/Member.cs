using System;
using System.Collections.Generic;

namespace CarForum.Models
{
    public class Member
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserImage { get; set; } = "user.jpg";
        public virtual string StandardTitle { get; set; } = "Member";
        public virtual string CustomTitle { get; set; } = "Member";
        public virtual string Signature { get; set; }
        public virtual ICollection<Thread> MemberThreads { get; set; }
        public virtual ICollection<Reply> MemberReplies { get; set; }
        public virtual DateTime RegistrationDate { get; set; } = DateTime.Now;
        public virtual DateTime? LastLogin { get; set; }
        public virtual DateTime? CurrentLogin { get; set; }
        public virtual bool Active { get; set; } = true;
        public virtual bool Online { get; set; } = false;
    }
}