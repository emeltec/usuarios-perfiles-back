using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosPerfiles.DTO
{
    public class PaginacionDTO
    {
        public int? pageNum { get; set; }
        public int? pageSize { get; set; }
        public int? totalRecord { get; set; }

        public int? totalPage { get; set; }
        public int? startIndex { get; set; }
        public int? sort { get; set; }
    }
}
