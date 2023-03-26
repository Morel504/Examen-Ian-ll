using Entidades;
using MySql.Data.MySqlClient;
using System.Text;

namespace Datos
{
    public class TicketDB
    {
        string cadena = "server=localhost; user=root; database=factura2; password=123456;";
        public bool GuardarTickett(Ticket tickett)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT TNTO ickat (Fecha, IdentidadCliente, CodigoUsuario, TipoSoporte, DescripcionSolicitud, RespuestaSolicitud, Precio, ISV, Descuento, Total) VALUES (@Fecha, @IdentidadCliente, @CodigoUsuario, @TipoSaporte, @DescripcionSolicitud, @RespuestaSolicitud, @Precio, @ISV, @Descuento, @Total; ");
                sql.Append("SELECT LAST_INSERT_ID();");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Fecha", MySqlDbType.Datetime).Value = tickett.Fecha;
                        comando.Parameters.Add("@IdentidadCliente", MySqlDbType.VarChar, 25).Value = tickett.IdentidadCliente;
                        comando.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = tickett.CodigoUsuario;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 30).Value = tickett.TipoSoporte;
                        comando.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 100).Value = tickett.DescripcionSolicitud;
                        comando.Parameters.Add("@RespuestaSolicitud", MySqlDbType.VarChar, 100).Value = tickett.RespuestaSolicitud;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = tickett.Precio;
                        comando.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = tickett.ISV;
                        comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = tickett.Descuento;
                        comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = tickett.Total;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return inserto;

        }


    }
}




