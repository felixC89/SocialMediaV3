using Microsoft.AspNetCore.Mvc;
using SocialMediaV3.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMediaV3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region Se crea la variable de contexto para inyeccion de dependencias
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository) 
        {
            _postRepository = postRepository;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPosts() 
        {
            var post = await _postRepository.GetPosts();
            return Ok(post);
        }

    }
}
