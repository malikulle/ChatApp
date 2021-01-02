using ChatApplication.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Core.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("UserRoles");

            builder.HasData(
                // Category.Create
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1

                },
                // Category.Read
                new UserRole
                {
                    UserId = 2,
                    RoleId = 1

                });
        }
    }

}
