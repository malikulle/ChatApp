using ChatApplication.Entities.Trackable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Entities.Domain
{
    public class Chat : BaseEntity,IEntity
    {
        public Chat()
        {
            Messages = new List<Message>();
            Users = new List<ChatUser>();
        }

        public string Name { get; set; }
        public ChatType Type { get; set; }

        public virtual List<Message> Messages { get; set; }
        public virtual List<ChatUser> Users { get; set; }
    }
    public enum ChatType
    {
        Room,
        Private
    }
}
