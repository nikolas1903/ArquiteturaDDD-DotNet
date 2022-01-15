using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models.Usuario.Requests;
using Domain.Utils;

namespace Domain.Interfaces.Usuario
{
    public interface IUsuarioAppService
    {
        Task<RespostaPadrao> Cadastrar(CadastrarUsuarioRequest request);

    }
}