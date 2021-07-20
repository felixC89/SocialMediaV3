using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaV3.InfraStructure.Repositories
{
    public class PostRepository:IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Post
            {
                PostId = x,
                Description = $"Descipcion {x}",
                Date = System.DateTime.Now,
                Image = $"https://misapps.com/{x}",
                UserId = x * 2
            });

            await Task.Delay(10);

            return  posts;
        }
    }
}
