using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosPerfiles.Abstraction.IAplication.Opciones;
using UsuariosPerfiles.DTO.Opciones;
using UsuariosPerfiles.DTO;
using System.Security.Claims;

namespace UsuariosPerfiles.API.Controllers.Opciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcionController : ControllerBase
    {
        private readonly IPerfilOpcionAplication iPerfilOpcionAplication;

        public OpcionController(IPerfilOpcionAplication _iPerfilOpcionAplication)
        {
            this.iPerfilOpcionAplication = _iPerfilOpcionAplication;
        }

        [HttpPost]
        [Route("GetListPerfilOpcion")]
        public async Task<ActionResult> GetListPerfilOpcion([FromBody] PerfilOpcionDTO request)
        {
            ResultDTO<PerfilOpcionDTO> res = new ResultDTO<PerfilOpcionDTO>();
            try
            {
                res = await iPerfilOpcionAplication.GetListPerfilOpcion(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                res.MessageExeption = ex.Message;
                return BadRequest(res);
            }
        }

    }
}
