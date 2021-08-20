using SocialMediaV3.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.Core.Interfaces
{
    public interface IPostService
    {
        Task<bool> DeletePost(int id);
        Task<Post> GetPost(int id);
        Task<IEnumerable<Post>> GetPosts();
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
    }
}