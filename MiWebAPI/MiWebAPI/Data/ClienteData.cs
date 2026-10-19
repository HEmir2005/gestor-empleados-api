using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class ClienteData
    {
        private readonly string conexion;

        public ClienteData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<bool> Registrar(Cliente objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.Cliente_Insertar", con);
                cmd.Parameters.AddWithValue("@Codigo", objeto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", objeto.Apellidos);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                cmd.Parameters.AddWithValue("@Activo", objeto.Activo);
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

        public async Task<List<Cliente>> ConsultarTodos()
        {
            List<Cliente> lista = new List<Cliente>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.Cliente_ConsultarTodos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaActualizacion = reader["FechaActualizacion"] == DBNull.Value ? null : Convert.ToDateTime(reader["FechaActualizacion"])
                            // Verifica si la fecha es nula en SQL (DBNull) para evitar excepciones; si es nula asigna null, de lo contrario la convierte a DateTime.
                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Cliente> ConsultarPorId(int Id)
        {
            Cliente objeto = new Cliente();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("dbo.Cliente_ConsultarPorId", con);
                cmd.Parameters.AddWithValue("@IdCliente", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        objeto = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"]),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                            FechaActualizacion = reader["FechaActualizacion"] == DBNull.Value ? null : Convert.ToDateTime(reader["FechaActualizacion"])
                        };
                    }
                }
            }
            return objeto;
        }

        public async Task<bool> Actualizar(Cliente objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.Cliente_Actualizar", con);
                cmd.Parameters.AddWithValue("@IdCliente", objeto.IdCliente);
                cmd.Parameters.AddWithValue("@Codigo", objeto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", objeto.Apellidos);
                cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                cmd.Parameters.AddWithValue("@Activo", objeto.Activo);
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

        public async Task<bool> DarDeBajaLogica(int id)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("dbo.Cliente_Eliminar", con);
                cmd.Parameters.AddWithValue("@IdCliente", id);
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
    }
}
