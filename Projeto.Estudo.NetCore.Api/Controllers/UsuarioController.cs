using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Estudo.NetCore.Domain.DTO;
using Projeto.Estudo.NetCore.Domain.Exceptions;
using Projeto.Estudo.NetCore.Domain.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Estudo.NetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _usuarioApplication.GetAsync(id));
        }

        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostAsync(UsuarioDto usuario)
        {
            await _usuarioApplication.AddAsync(usuario);
            return Created("", usuario);
        }

        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch]
        public async Task<IActionResult> PatchAsync(UsuarioDto usuario)
        {
            await _usuarioApplication.UpdateAsync(usuario);
            return NoContent();
        }

        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _usuarioApplication.DeleteAsync(id);
            return NoContent();
        }

    }
}
