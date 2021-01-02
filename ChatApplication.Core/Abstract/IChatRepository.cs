using ChatApplication.Entities.Domain;
using ChatApplication.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Core.Abstract
{
    public interface IChatRepository : IRepository<Chat>
    {

    }
}
