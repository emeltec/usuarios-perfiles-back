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
    public class PerfilAplication : IPerfilAplication
    {
        private readonly IPerfilService iPerfilService;

        public PerfilAplication(IPerfilService _iPerfilService)
        {
            this.iPerfilService = _iPerfilService;
        }

        public Task<ResultDTO<PerfilDTO>> GetListPerfil(PerfilDTO request)
        {
            return this.iPerfilService.GetListPerfil(request);
        }

        public Task<ResultDTO<PerfilDTO>> RegisterPerfil(PerfilDTO request)
        {
            return iPerfilService.RegisterPerfil(request);
        }
    }
}
