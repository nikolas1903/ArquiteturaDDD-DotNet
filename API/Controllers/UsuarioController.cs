using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Usuario;
using Domain.Models.Usuario.Requests;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChurras.Controllers
{
    
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }


        [Produces("application/json")]
        [HttpPost("Cadastrar")]
        public async Task<RespostaPadrao> Cadastro([FromBody] CadastrarUsuarioRequest request)
        {
            return await _usuarioAppService.Cadastrar(request);
        }
    }
}