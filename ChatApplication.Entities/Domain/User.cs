using ChatApplication.Entities.Trackable;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Entities.Domain
{
    public class User : IdentityUser<int>
    {
        public List<ChatUser> Chats { get; set; }
    }
}
