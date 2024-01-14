using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.Abstraction.IRepository.Perfiles;
using UsuariosPerfiles.Abstraction.IService.Opciones;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;

namespace UsuariosPerfiles.Services.Opciones
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository iPerfilRepository;

        public PerfilService(IPerfilRepository _iPerfilRepository)
        {
            this.iPerfilRepository = _iPerfilRepository;
        }
        public Task<ResultDTO<PerfilDTO>> GetListPerfil(PerfilDTO request)
        {
            return this.iPerfilRepository.GetListPerfil(request);
        }

        public Task<ResultDTO<PerfilDTO>> RegisterPerfil(PerfilDTO request)
        {
            return iPerfilRepository.RegisterPerfil(request);
        }
    }
}
