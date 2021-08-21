using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.Core.Services
{
    public class PostService : IPostService
    {
        #region Inyeccion de dependencia
        private readonly IUnitOfWork _UnitOfWork;
        
        public PostService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
            
        }
        #endregion

        public async Task<Post> GetPost(int id)
        {
            return await _UnitOfWork.postRepository.GetById(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _UnitOfWork.postRepository.GetAll();
        }

        public async Task InsertPost(Post post)
        {
            var user = await _UnitOfWork.userRepository.GetById(post.UserId);

            if(user == null) { throw new Exception("El usuario no existe!"); }

            if (post.Description.Contains("sexo")) { throw new Exception("Contenido no permitido!"); }

            await _UnitOfWork.postRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
             await _UnitOfWork.postRepository.Update(post);

            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _UnitOfWork.postRepository.Delete(id);

            return true;
        }
    }
}
