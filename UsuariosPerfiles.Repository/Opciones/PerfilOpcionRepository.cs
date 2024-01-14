using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosPerfiles.Abstraction.IRepository.Perfiles;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;
using UsuariosPerfiles.Abstraction.IRepository.Opciones;

namespace UsuariosPerfiles.Repository.Opciones
{
    public class PerfilOpcionRepository : IPerfilOpcionRepository
    {
        private string connectionString = "";
        private IConfiguration configuration;

        public PerfilOpcionRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
            connectionString = configuration.GetConnectionString("Conn_string1");
        }

        public async Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcion(PerfilOpcionDTO request)
        {
            ResultDTO<PerfilOpcionDTO> res = new ResultDTO<PerfilOpcionDTO>();
            List<PerfilOpcionDTO> list = new List<PerfilOpcionDTO>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@p_id_perfil", request.id_perfil);

                using (var conn = new SqlConnection(connectionString))
                {
                    list = (List<PerfilOpcionDTO>) await conn.QueryAsync<PerfilOpcionDTO>("[dbo].[SP_PERFIL_OPCION_LISTAR]", parameters, commandType: CommandType.StoredProcedure);
                }

                res.IsSuccess = list.ToList().Count > 0 ? true : false;
                res.Message = "Informacion encontrada";
                //res.totalregistro = (int)(list.ToList().Count > 0 ? list[0].totalRecord : 0);
                res.data = list.ToList();
            } 
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Informacion No encontrada";
                res.data = new List<PerfilOpcionDTO>();
                res.MessageExeption = ex.Message.ToString();
            }

            return res;
        }

        public async Task<ResultDTO<PerfilOpcionDTO>> GetListPerfilOpcionNuevo(PerfilOpcionDTO request)
        {
            ResultDTO<PerfilOpcionDTO> res = new ResultDTO<PerfilOpcionDTO>();
            List<PerfilOpcionDTO> list = new List<PerfilOpcionDTO>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@p_id_perfil", request.id_perfil);

                using (var conn = new SqlConnection(connectionString))
                {
                    list = (List<PerfilOpcionDTO>) await conn.QueryAsync<PerfilOpcionDTO>("[dbo].[SP_PERFIL_OPCION_NUEVO_LISTAR]", parameters, commandType: CommandType.StoredProcedure);
                }

                res.IsSuccess = list.ToList().Count > 0 ? true : false;
                res.Message = "Informacion encontrada";
                //res.totalregistro = (int)(list.ToList().Count > 0 ? list[0].totalRecord : 0);
                res.data = list.ToList();
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Informacion No encontrada";
                res.data = new List<PerfilOpcionDTO>();
                res.MessageExeption = ex.Message.ToString();
            }

            return res;
        }

        public async Task<ResultDTO<PerfilOpcionDTO>> RegisterPerfilOpcion(List<PerfilOpcionDTO> request)
        {
            ResultDTO<PerfilOpcionDTO> res = new ResultDTO<PerfilOpcionDTO>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    foreach (PerfilOpcionDTO x in request)
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@p_id_perfil_opcion", x.id_perfil_opcion);
                        parameters.Add("@p_id_perfil", x.id_perfil);
                        parameters.Add("@p_id_opcion", x.id_opcion);
                        parameters.Add("@p_acceso_crear", x.acceso_crear);
                        parameters.Add("@p_acceso_actualizar", x.acceso_actualizar);
                        parameters.Add("@p_acceso_eliminar", x.acceso_eliminar);
                        parameters.Add("@p_acceso_visualizar", x.acceso_visualizar);

                        using (var lector = await cn.ExecuteReaderAsync("[dbo].[SP_PERFIL_OPCION_REGISTAR]", parameters, commandType: CommandType.StoredProcedure))
                        {
                            while (lector.Read())
                            {
                                res.Codigo = Convert.ToInt32(lector["id"].ToString());
                                res.IsSuccess = true;
                                res.Message = "Información registrada";
                            }
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Informacion no registrada";
                res.MessageExeption = ex.Message.ToString();
            }

            return res;
        }
    }
}
