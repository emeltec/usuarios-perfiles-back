using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.DTO.Opciones;
using UsuariosPerfiles.DTO;

namespace UsuariosPerfiles.Abstraction.IService.Opciones
{
    public interface IPerfilService
    {
        public Task<ResultDTO<PerfilDTO>> GetListPerfil(PerfilDTO request);
        public Task<ResultDTO<PerfilDTO>> RegisterPerfil(PerfilDTO request);
    }
}
