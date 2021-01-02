using ChatApplication.Core.Abstract;
using ChatApplication.Core.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Core.Concrete.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatAppContext _context;
        private EfChatRepository _chatRepo;
        private EfMessageRepository _messageRepo;
        private EfChatUserRepository _chatUserRepo;

        public UnitOfWork(ChatAppContext context)
        {
            _context = context;
        }

        public IChatRepository ChatRepository => _chatRepo ?? new EfChatRepository(_context);

        public IMessageRepository MessageRepository => _messageRepo ?? new EfMessageRepository(_context);

        public IChatUserRepository ChatUserRepository => _chatUserRepo ?? new EfChatUserRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
