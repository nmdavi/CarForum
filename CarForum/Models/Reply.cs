using System;

namespace CarForum.Models
{
    public class Reply
    {
        public virtual int Id { get; set; }
        public virtual string ReplyText { get; set; }
        public virtual DateTime CreationDate { get; set; } = DateTime.Now;
        public virtual Member ReplyCreator { get; set; }
        public virtual Thread ReplyThread { get; set; }
    }
}