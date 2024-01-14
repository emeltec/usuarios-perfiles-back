using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosPerfiles.DTO.Opciones
{
    public class PerfilDTO: PaginacionDTO
    {
        public int? id_perfil { get; set; }
        public string? nombre_perfil { get; set; }
        public string? descripcion_perfil { get; set; }
        public int? estado_registro { get; set; }
    }
}
