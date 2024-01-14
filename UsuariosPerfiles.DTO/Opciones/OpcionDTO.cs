using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosPerfiles.DTO.Opciones
{
    public class OpcionDTO
    {
        public int id_opcion { get; set; }
        public int id_modulo { get; set; }
        public int orden { get; set; }
        public string titulo { get; set; }
        public string icono { get; set; }
        public string url { get; set; }
    }
}
