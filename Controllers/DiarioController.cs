using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autenticacao01.Authentication;
using Autenticacao01.DTOs;
using Autenticacao01.Models;
using Autenticacao01.Repositories;
using Autenticacao01.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao01.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DiarioController : ControllerBase
    {
        private readonly IDiarioRepository _diarioRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public DiarioController(IDiarioRepository postRepository, 
                                UserManager<ApplicationUser> userManager, 
                                IUserService userService,
                                IMapper mapper)
        {
            _diarioRepository = postRepository;
            this.userManager = userManager;
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            List<DiarioResponseDTO> diariosDTO = new List<DiarioResponseDTO>();
            var diarios = await _diarioRepository.GetDiarios(await userService.GetUser(User));

            foreach (var diario in diarios)
            {
                var diarioDTO = mapper.Map<DiarioResponseDTO>(diario);
                diariosDTO.Add(diarioDTO);
            }

            return Ok(diariosDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _diarioRepository.GetDiarioById(id, await userService.GetUser(User));
            var postDTO = mapper.Map<DiarioResponseDTO>(post);
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(DiarioRequestDTO diarioDTO)
        {
            var diario = mapper.Map<Diario>(diarioDTO);

            diario.UserId = await userService.GetUser(User);
            //diario.UserId = await userManager.GetUserIdAsync(await userManager.GetUserAsync(User));
            await _diarioRepository.Add(diario, await userService.GetUser(User));
            return CreatedAtAction(nameof(GetPost), new { id = diario.Id }, diarioDTO);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(DiarioRequestDTO diarioDTO)
        {
            var diario = mapper.Map<Diario>(diarioDTO);

            await _diarioRepository.Update(diario, await userService.GetUser(User));
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePost(int id)
        {
            var user = await userManager.GetUserAsync(User);
            
            await _diarioRepository.Delete(id, await userService.GetUser(User));
            return Ok("Removed");           
        }

    }
}