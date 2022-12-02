using Domain.DTOs.Input;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/GerarToken")]
        public async Task<IActionResult> GerarToken([FromBody] UsuarioLogin login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
                return BadRequest("Informe email e/ou senha");

            var resultadoAutenticar = await _usuarioService.AutenticarUsuarioAsync(login);
            if (resultadoAutenticar.Succeeded)
            {
                var resultadoEmail = await _usuarioService.BuscarUsuarioPorEmailAsync(login.Email);
                if (resultadoEmail is not null)
                {
                    var tokenOutput = _usuarioService.GerarToken(resultadoEmail);
                    return Ok(tokenOutput);
                }
                else
                    return Unauthorized("Usuário não localizado.");
            }
            else
                return Unauthorized("Usuário e/ou senha inálido.");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioLogin login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
                return Ok("Dados para cadastro são incompletos.");

            var resultadoEmail = await _usuarioService.BuscarUsuarioPorEmailAsync(login.Email);
            if (resultadoEmail is not null)
                return BadRequest("Email já esta sendo utilizado por outro usuário");


            var resultadoInserir = await _usuarioService.InserirUsuarioAsync(login);
            if (resultadoInserir.Errors.Any())
                return Ok(resultadoInserir.Errors);

            return BadRequest();
            //// Geração de Confirmação caso precise 
            //await _userManager.GetUserIdAsync(usuario);
            //var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //// retorno email
            //code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            //var resultado2 = await _userManager.ConfirmEmailAsync(usuario, code);

            //if (resultado2.Succeeded)
            //    return Ok("Usuário Adicionado com Sucesso");
            //else
            //    return Ok("Erro ao confirmar usuários");
        }
    }
}
