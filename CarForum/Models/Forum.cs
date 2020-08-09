using System.Collections.Generic;

namespace CarForum.Models
{
    public class Forum
    {
        public virtual int Id { get; set; }
        public virtual string ForumTitle { get; set; }
        public virtual string ForumDesc { get; set; }
        public virtual Section ForumSection { get; set; }
        public virtual ICollection<Thread> ForumThreads { get; set; }
    }
}