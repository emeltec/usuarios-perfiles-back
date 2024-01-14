using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.DTO.Opciones;
using UsuariosPerfiles.DTO;

namespace UsuariosPerfiles.Abstraction.IService.Opciones
{
    public interface IPerfilOpcionService
    {
        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcion(PerfilOpcionDTO request);

        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcionNuevo(PerfilOpcionDTO request);

        public Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(PerfilDTORequest request);

        public Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(List<PerfilOpcionDTO> request);
    }
}
