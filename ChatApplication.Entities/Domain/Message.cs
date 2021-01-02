using ChatApplication.Entities.Trackable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Entities.Domain
{
    public class Message : BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        
    }
}
