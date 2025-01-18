using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Entities
{
    public class CommentaryEntity : BaseEntity
    {
        public string Body { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int TopicId { get; set; }
    }
}
