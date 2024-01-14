using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;

namespace UsuariosPerfiles.Abstraction.IAplication.Opciones
{
    internal interface IOpcionAplication
    {
        public Task<ResultDTO<PerfilOpcionDTO>> GetListOpcionByModulo(ModuloDTO request);
    }
}
