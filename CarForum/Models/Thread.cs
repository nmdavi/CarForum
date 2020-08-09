using System;
using System.Collections.Generic;

namespace CarForum.Models
{
    public class Thread
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime CreationDate { get; set; } = DateTime.Now;
        public virtual int Views { get; set; } = 0;
        public virtual string Text { get; set; }
        public virtual Member ThreadCreator { get; set; }
        public virtual Forum ThreadForum { get; set; }
        public virtual ICollection<Reply> ThreadReplies { get; set; }
    }
}