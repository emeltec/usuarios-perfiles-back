using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.Abstraction.IAplication.Opciones;
using UsuariosPerfiles.Abstraction.IService.Opciones;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;

namespace UsuariosPerfiles.Aplication.Opciones
{
    public class PerfilOpcionAplication : IPerfilOpcionAplication
    {
        private readonly IPerfilOpcionService iPerfilOpcionService;

        public PerfilOpcionAplication(IPerfilOpcionService _iPerfilOpcionService)
        {
            this.iPerfilOpcionService = _iPerfilOpcionService;
        }

        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcion(PerfilOpcionDTO request)
        {
            return iPerfilOpcionService.GetListPerfilOpcion(request);
        }

        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcionNuevo(PerfilOpcionDTO request)
        {
            return iPerfilOpcionService.GetListPerfilOpcionNuevo(request);
        }

        public Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(PerfilDTORequest request)
        {
            return iPerfilOpcionService.RegisterPerfilOpcion(request);
        }

        public Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(List<PerfilOpcionDTO> request)
        {
            throw new NotImplementedException();
        }
    }
}
