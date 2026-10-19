using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class ProveedorData
    {
        private readonly string conexion;

        public ProveedorData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<bool> Crear(Proveedor objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.PROVEEDOR_AGREGA", con);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido_paterno", objeto.Apellido_Paterno);
                cmd.Parameters.AddWithValue("@Apellido_materno", objeto.Apellido_Materno);
                cmd.Parameters.AddWithValue("@Rfc", objeto.Rfc);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Credito", objeto.Credito);
                cmd.Parameters.AddWithValue("@Nombre_Banco", objeto.Nombre_Banco);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<List<Proveedor>> Lista()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.PROVEEDOR_SELECCIONA", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Proveedor
                        {
                            Id = Convert.ToInt64(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido_Paterno = reader["Apellido_Paterno"].ToString(),
                            Apellido_Materno = reader["Apellido_Materno"].ToString(),
                            Rfc = reader["Rfc"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Credito = Convert.ToDecimal(reader["Credito"]),
                            Nombre_Banco = reader["Nombre_Banco"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<bool> Actualizar(Proveedor objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.PROVEEDOR_ACTUALIZA", con);
                cmd.Parameters.AddWithValue("@Id", objeto.Id);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Apellido_paterno", objeto.Apellido_Paterno);
                cmd.Parameters.AddWithValue("@Apellido_materno", objeto.Apellido_Materno);
                cmd.Parameters.AddWithValue("@Rfc", objeto.Rfc);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Credito", objeto.Credito);
                cmd.Parameters.AddWithValue("@Nombre_Banco", objeto.Nombre_Banco);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<bool> Eliminar(long id)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.PROVEEDOR_ELIMINA", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<Proveedor> ObtenerId(long Id)
        {
            Proveedor objeto = new Proveedor();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.PROVEEDOR_SELECCIONAPORID", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        objeto = new Proveedor
                        {
                            Id = Convert.ToInt64(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido_Paterno = reader["Apellido_Paterno"].ToString(),
                            Apellido_Materno = reader["Apellido_Materno"].ToString(),
                            Rfc = reader["Rfc"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Credito = Convert.ToDecimal(reader["Credito"]),
                            Nombre_Banco = reader["Nombre_Banco"].ToString()
                        };
                    }
                }
            }
            return objeto;
        }
    }
}
