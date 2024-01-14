using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosPerfiles.DTO.Opciones
{
    public class PerfilOpcionDTO: PaginacionDTO
    {
        public int? id_perfil_opcion { get; set; }
        public int? id_modulo { get; set; }
        public int id_perfil { get; set; }
        public int? id_opcion { get; set; }
        public string? modulo_titulo { get; set; }
        public string? opcion_titulo { get; set; }
        public string? opcion_url { get; set; }
        public string? nombre_perfil { get; set; }
        public bool? acceso_visualizar { get; set; }
        public bool? acceso_crear { get; set; }
        public bool? acceso_actualizar { get; set; }
        public bool? acceso_eliminar { get; set; }
    }

    public class PerfilDTORequest
    {
        public PerfilDTO perfil { get; set; }
        public List<PerfilOpcionDTO> perfilOpcion { get; set; }
    }
}
