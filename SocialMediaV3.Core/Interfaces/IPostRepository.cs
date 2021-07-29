using SocialMediaV3.Core.DTOs;
using SocialMediaV3.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPost(int id);

        Task InsertPost(Post post);

        Task<bool> UpdatePost(Post post);

        Task<bool> DeletePost(int id);
    }
}
