using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebRota.Domain.Entities;
using WebRota.Domain.Interfaces;

namespace WebRota.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Save( [FromBody] User model)
        {
            try
            {
                var user = _userRepository.Save(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao salvar usuario.");
            }
        }
       

        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<User>> Delete([FromQuery] long id)
        {
            try
            {
                var user = _userRepository.Delete(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar usuario.");
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<User>> Get([FromQuery] long id)
        {
            try
            {
                var user = _userRepository.Get(id);
                if (user == null)
                    return NotFound("Usuario não encontrado!");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao carregar usuario.");
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<User>> Update([FromBody] User User)
        {
            try
            {
                if (User.Id == null || User.Id == 0)
                    return BadRequest("O Id é obrigatorio");

                var user = _userRepository.Update(User);
                
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao carregar usuario.");
            }
        }

    }
}
