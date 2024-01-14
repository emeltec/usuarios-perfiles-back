using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosPerfiles.DTO
{
    public class ResultDTO<T>
    {
        public int Codigo { get; set; }
        public Boolean IsSuccess { get; set; }
        public string Message { get; set; }
        public string MessageExeption { get; set; }
        public List<T> data { get; set; }
        public T item { get; set; }
        public int totalregistro { get; set; }
    }
}
