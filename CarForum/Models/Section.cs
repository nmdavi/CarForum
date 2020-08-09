using System.Collections.Generic;

namespace CarForum.Models
{
    public class Section
    {
        public virtual int Id { get; set; }
        public virtual string SectionTitle { get; set; }
        public virtual ICollection<Forum> SectionForums { get; set; }
    }
}