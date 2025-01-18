using CMSPlus.Domain.Models.TopicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Models.CommentaryModels
{
    public class CommentaryCreateModel : BaseCommentaryModel
    {
         public string Name { get; set; }
         public string LastName { get; set; }
         public string Body { get; set; }
      
    }
}
