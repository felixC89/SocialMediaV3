using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using SocialMediaV3.InfraStructure.Data;
using System.Threading.Tasks;

namespace SocialMediaV3.InfraStructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediadbContext _context;
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public UnitOfWork(SocialMediadbContext context)
        {
            _context = context;
        }
        public IRepository<Post> postRepository => _postRepository ?? new BaseRepository<Post>(_context);

        public IRepository<User> userRepository => _userRepository ?? new BaseRepository<User>(_context);

        public IRepository<Comment> commentRepository => _commentRepository ?? new BaseRepository<Comment>(_context);

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
