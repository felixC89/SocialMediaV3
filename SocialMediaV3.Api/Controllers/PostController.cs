using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMediaV3.Api.Response;
using SocialMediaV3.Core.DTOs;
using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        #region Se crea la variable de contexto para inyeccion de dependencias
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetPosts();

            var PostsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            var response = new ApiResponse<IEnumerable<PostDto>>(PostsDto);

            return Ok(response);
        }

        [HttpGet("{id}")]//Se agrega para indicar que en este endpoint se recibira un parametro en la peticion get
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);

            var PostDto = _mapper.Map<PostDto>(post);

            var response = new ApiResponse<PostDto>(PostDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postdto)
        {
            var post = _mapper.Map<Post>(postdto);

            await _postService.InsertPost(post);

            var respostdto = _mapper.Map<PostDto>(post);

            var response = new ApiResponse<PostDto>(respostdto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,PostDto postdto)
        {
            var post = _mapper.Map<Post>(postdto);
            post.Id = id;

            var resu = await _postService.UpdatePost(post);

            var response = new ApiResponse<bool>(resu);

            return Ok(response);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resu = await _postService.DeletePost(id);

            var response = new ApiResponse<bool>(resu);

            return Ok(response);
        }

    }
}
