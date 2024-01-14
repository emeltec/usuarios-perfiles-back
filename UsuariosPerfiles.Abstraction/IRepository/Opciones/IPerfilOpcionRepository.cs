using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;

namespace UsuariosPerfiles.Abstraction.IRepository.Opciones
{
    public interface IPerfilOpcionRepository
    {
        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcion(PerfilOpcionDTO request);

        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcionNuevo(PerfilOpcionDTO request);

        public Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(List<PerfilOpcionDTO> request);
    }
}
