using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.Abstraction.IRepository.Opciones;
using UsuariosPerfiles.Abstraction.IRepository.Perfiles;
using UsuariosPerfiles.Abstraction.IService.Opciones;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;

namespace UsuariosPerfiles.Services.Opciones
{
    public class PerfilOpcionService : IPerfilOpcionService
    {
        private readonly IPerfilOpcionRepository iPerfilOpcionRepository;
        private readonly IPerfilRepository iPerfilRepository;

        public PerfilOpcionService(IPerfilOpcionRepository _iPerfilOpcionRepository, IPerfilRepository _iPerfilRepository)
        {
            this.iPerfilOpcionRepository = _iPerfilOpcionRepository;
            this.iPerfilRepository = _iPerfilRepository;
        }

        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcion(PerfilOpcionDTO request)
        {
            return iPerfilOpcionRepository.GetListPerfilOpcion(request);
        }

        public Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcionNuevo(PerfilOpcionDTO request)
        {
            return iPerfilOpcionRepository.GetListPerfilOpcionNuevo(request);
        }

        public async Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(PerfilDTORequest request)
        {
            ResultDTO<PerfilOpcionDTO> res = new ResultDTO<PerfilOpcionDTO>();
            try
            {
                var res_per = await iPerfilRepository.RegisterPerfil(request.perfil);
                if (!res_per.IsSuccess)
                {
                    throw new Exception("" + res_per.MessageExeption);
                }

                foreach (PerfilOpcionDTO x in request.perfilOpcion)
                {
                    x.id_perfil = res_per.Codigo;
                }

                if (request.perfilOpcion.Count != 0)
                {
                    var res_peropc = await this.iPerfilOpcionRepository.RegisterPerfilOpcion(request.perfilOpcion);
                    if (!res_peropc.IsSuccess)
                    {
                        throw new Exception("" + res_per.MessageExeption);
                    }
                }


                res.Codigo = res_per.Codigo;
                res.IsSuccess = true;
                res.Message = "Información registrada";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Información no registrado";
                res.MessageExeption = ex.Message;
            }

            return res;
        }

        public Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(List<PerfilOpcionDTO> request)
        {
            throw new NotImplementedException();
        }
    }
}
