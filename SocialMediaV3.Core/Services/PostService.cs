using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.Core.Services
{
    public class PostService : IPostService
    {
        #region Inyeccion de dependencia
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        #endregion

        public async Task<Post> GetPost(int id)
        {
            return await _postRepository.GetPost(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _postRepository.GetPosts();
        }

        public async Task InsertPost(Post post)
        {
            await _postRepository.InsertPost(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            return await _postRepository.UpdatePost(post);
        }

        public async Task<bool> DeletePost(int id)
        {
            return await _postRepository.DeletePost(id);
        }
    }
}
