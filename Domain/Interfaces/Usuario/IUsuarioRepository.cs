using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models.Usuario.Requests;
using Domain.Utils;

namespace Domain.Interfaces.Usuario
{
    public interface IUsuarioRepository<TUsuarioEntity> where TUsuarioEntity : UsuarioEntity
    {
        Task<CadastrarUsuarioRequest> CadastrarUsuario(CadastrarUsuarioRequest request);
        Task<UsuarioEntity> BuscarUsuario(CadastrarUsuarioRequest usuario);
    }
}