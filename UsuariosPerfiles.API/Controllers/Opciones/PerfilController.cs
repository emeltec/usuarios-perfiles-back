using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UsuariosPerfiles.Abstraction.IAplication.Opciones;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;

namespace UsuariosPerfiles.API.Controllers.Perfiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilAplication iPerfilAplication;
        private readonly IPerfilOpcionAplication iPerfilOpcionAplication;

        public PerfilController(IPerfilAplication _iPerfilAplication, IPerfilOpcionAplication _iPerfilOpcionAplication)
        {
            this.iPerfilAplication = _iPerfilAplication;
            this.iPerfilOpcionAplication = _iPerfilOpcionAplication;
        }

        [HttpPost]
        [Route("GetListPerfil")]
        public async Task<ActionResult> GetListPerfil([FromBody] PerfilDTO request)
        {
            ResultDTO<PerfilDTO> res = new ResultDTO<PerfilDTO>();
            try
            {
                res = await this.iPerfilAplication.GetListPerfil(request);
                return Ok(res);
            }
            catch (Exception ex)
            { 
                res.MessageExeption = ex.Message;
                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("RegisterPerfil")]
        public async Task<ActionResult> RegisterPerfil([FromBody] PerfilDTO request)
        {
            ResultDTO<PerfilDTO> res = new ResultDTO<PerfilDTO>();
            try
            {
                res = await this.iPerfilAplication.RegisterPerfil(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                res.MessageExeption = e.Message.ToString();
                return BadRequest(res);
            }
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

        [HttpPost]
        [Route("GetListPerfilOpcionNuevo")]
        public async Task<ActionResult> GetListPerfilOpcionNuevo([FromBody] PerfilOpcionDTO request)
        {
            ResultDTO<PerfilOpcionDTO> res = new ResultDTO<PerfilOpcionDTO>();
            try
            {
                res = await this.iPerfilOpcionAplication.GetListPerfilOpcionNuevo(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                res.MessageExeption = e.Message.ToString();


                return BadRequest(res);
            }
        }

        [HttpPost]
        [Route("RegisterPerfilOpcion")]
        public async Task<ActionResult> RegisterPerfilOpcion([FromBody] PerfilDTORequest request)
        {
            ResultDTO<PerfilOpcionDTO> res = new ResultDTO<PerfilOpcionDTO>();
            try {
                PerfilDTO per = new PerfilDTO();
                per.id_perfil = request.perfil.id_perfil;
                per.estado_registro = 1;
                per.pageNum = 0;
                per.pageSize = 100;
                per.nombre_perfil = "";

                var res_perfil = await iPerfilAplication.GetListPerfil(per);

                if (
                    request.perfil.id_perfil > 0 && 
                    res_perfil.data.FindAll(x => x.nombre_perfil.ToUpper() == request.perfil.nombre_perfil.ToUpper()).Count() > 0 
                   )
                {
                    res.IsSuccess = false;
                    res.item = null;
                    res.data = null;
                    res.Message = "Perfil Duplicado";
                } else
                {
                    res = await iPerfilOpcionAplication.RegisterPerfilOpcion(request);
                }

                return Ok(res);
            }
            catch(Exception ex)
            {
                res.MessageExeption = ex.Message;
                res.IsSuccess = false;
                
                return BadRequest(res);
            }
        }
    }
}
