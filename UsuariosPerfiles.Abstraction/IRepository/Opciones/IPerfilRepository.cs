using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;

namespace UsuariosPerfiles.Abstraction.IRepository.Perfiles
{
    public interface IPerfilRepository
    {
        public Task<ResultDTO<PerfilDTO>> GetListPerfil(PerfilDTO request);
        public Task<ResultDTO<PerfilDTO>> RegisterPerfil(PerfilDTO request);
    }
}
