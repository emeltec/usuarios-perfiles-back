using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UsuariosPerfiles.Abstraction.IRepository.Perfiles;
using UsuariosPerfiles.DTO;
using UsuariosPerfiles.DTO.Opciones;
using Microsoft.Extensions.Configuration;

namespace UsuariosPerfiles.Repository.Opciones
{
    public class PerfilRepository : IPerfilRepository
    {
        private string connectionString = "";
        private IConfiguration? configuration;

        public PerfilRepository(IConfiguration _configuration) 
        {
            configuration = _configuration;
            connectionString = configuration.GetConnectionString("Conn_string1");
        }
        public async Task<ResultDTO<PerfilDTO>> GetListPerfil(PerfilDTO request)
        {
            ResultDTO<PerfilDTO> res = new ResultDTO<PerfilDTO>();
            List<PerfilDTO> list = new List<PerfilDTO>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@p_nombre_perfil", request.nombre_perfil);

                using(var conn = new SqlConnection(connectionString))
                {
                    list = (List<PerfilDTO>) await conn.QueryAsync<PerfilDTO>("[dbo].[SP_PERFIL_LISTAR]", parameters, commandType: CommandType.StoredProcedure);
                }

                res.IsSuccess = list.ToList().Count > 0 ? true : false;
                res.Message = "Informacion encontrada";
                res.totalregistro = (int)(list.ToList().Count > 0 ? list[0].totalRecord : 0);
                res.data = list.ToList();
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Informacion no encontrada";
                res.data = new List<PerfilDTO>();
                res.MessageExeption = ex.Message.ToString();
            }

            return res;
        }

        public async Task<ResultDTO<PerfilDTO>> RegisterPerfil(PerfilDTO request)
        {
            ResultDTO<PerfilDTO> res = new ResultDTO<PerfilDTO>();
            try {
                using (var cn = new SqlConnection(connectionString)) 
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@p_id_perfil", request.id_perfil);
                    parameters.Add("@p_nombre_perfil", request.nombre_perfil);
                    parameters.Add("@p_descripcion_perfil", request.descripcion_perfil);
                    parameters.Add("@p_estado_registro", request.estado_registro);

                    using (var lector = await cn.ExecuteReaderAsync("[dbo].[SP_PERFIL_REGISTRAR]", parameters, commandType: CommandType.StoredProcedure))
                    {
                        while (lector.Read())
                        {
                            res.Codigo = Convert.ToInt32(lector["id"].ToString());
                            res.IsSuccess = true;
                            res.Message = "Perfil registrado o actualizado";
                        }
                    }
                    //await mConnection.Complete();
                }
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = "Perfil no registrado";
                res.MessageExeption = ex.Message;
            }

            return res;
        }

     
    }
}
