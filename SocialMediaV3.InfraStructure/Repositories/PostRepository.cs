using Microsoft.EntityFrameworkCore;
using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using SocialMediaV3.InfraStructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaV3.InfraStructure.Repositories
{
    public class PostRepository:IPostRepository
    {
        #region Inyeccion de dependencias de la base de datos scaffoldeada con EF 
        private readonly SocialMediadbContext _context;

        public PostRepository(SocialMediadbContext context) 
        {
            _context = context;
        }
        #endregion

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return  posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x=> x.PostId == id);

            return post;
        }

        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

        }
    }
}
