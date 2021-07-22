using Microsoft.AspNetCore.Mvc;
using SocialMediaV3.Core.Entities;
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
            var posts = await _postRepository.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]//Se agrega para indicar que en este endpoint se recibira un parametro en la peticion get
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            await _postRepository.InsertPost(post);
            return Ok(post);
        }

    }
}
