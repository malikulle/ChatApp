using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Core.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IChatRepository ChatRepository { get; }
        IMessageRepository MessageRepository { get; }
        IChatUserRepository ChatUserRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
