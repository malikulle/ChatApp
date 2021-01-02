using ChatApplication.Entities.Trackable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Entities.Domain
{
    public class ChatUser : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        public UserRoleEnum UserRole { get; set; }

    }
    public enum UserRoleEnum
    {
        Admin, Member, Guest
    }
}
