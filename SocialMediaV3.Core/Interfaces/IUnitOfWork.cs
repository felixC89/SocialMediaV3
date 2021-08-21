using SocialMediaV3.Core.Entities;
using System;
using System.Threading.Tasks;

namespace SocialMediaV3.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Post> postRepository { get; }

        IRepository<User> userRepository { get; }

        IRepository<Comment> commentRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
