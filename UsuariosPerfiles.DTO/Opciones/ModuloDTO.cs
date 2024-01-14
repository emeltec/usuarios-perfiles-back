using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosPerfiles.DTO.Opciones
{
    public class ModuloDTO
    {
        public int id_modulo { get; set; }
        public string titulo { get; set; }
        public string url { get; set; }
        public string icono { get; set; }
        public int orden { get; set; }

        public List<OpcionDTO> opcion { set; get; }
    }
}
