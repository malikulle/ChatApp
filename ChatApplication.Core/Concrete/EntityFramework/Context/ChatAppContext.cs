using ChatApplication.Core.Concrete.EntityFramework.Mappings;
using ChatApplication.Entities.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Core.Concrete.EntityFramework.Context
{
    public class ChatAppContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ChatAppContext(DbContextOptions<ChatAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new UserTokenMap());
        }

        #region Tables

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }

        #endregion
    }
}
