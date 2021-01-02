using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Entities.Trackable
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
