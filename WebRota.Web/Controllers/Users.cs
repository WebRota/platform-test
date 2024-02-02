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
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromQuery] string email, [FromQuery] string password)
        { 
            try
            {
                var user = _userRepository.login(email, password);

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                var token = user.GenerateToken();
                user.Password = "";
                return new
                {
                    token = token
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Algo deu errado, tente mais tarde!" });
            }

        }




        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Save([FromBody] User model)
        {
            try
            {
                var user = _userRepository.Save(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
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
