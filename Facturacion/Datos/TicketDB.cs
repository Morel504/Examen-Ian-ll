using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class TicketDB
    {
        string cadena = "server=localhost; user=root; database=factura2; password=123456;";

        public bool Guardar(Ticket ticket, List<DetalleTicket> detalles)
        {
            bool inserto = false;
            int idFactura = 0;
            try
            {
                StringBuilder sqlTicket = new StringBuilder();
                sqlTicket.Append(" INSERT INTO ticket (Id, Fecha, IdentidadCliente, CodigoUsuario, TipoSoporte, DescripcionSolicitud, RespuestaSolicitud, Precio, ISV, Descuento, Total) VALUES (@Id, @Fecha, @IdentidadCliente, @CodigoUsuario, @TipoSoporte, @DescripcionSolicitud, @RespuestaSolicitud, @Precio, @ISV, @Descuento, @Total); ");
                sqlTicket.Append(" SELECT LAST_INSERT_ID(); ");

                StringBuilder sqlDetalle = new StringBuilder();
                sqlDetalle.Append(" INSERT INTO detalleticket (Id, Fecha, IdentidadCliente, CodigoUsuario, TipoSoporte, DescripcionSolicitud, RespuestaSolicitud, Precio, ISV, Descuento, Total) VALUES (@Id, @Fecha, @IdentidadCliente, @CodigoUsuario, @TipoSoporte, @DescripcionSolicitud, @RespuestaSolicitud, @Precio, @ISV, @Descuento, @Total); ");


                using (MySqlConnection con = new MySqlConnection(cadena))
                {
                    con.Open();

                    MySqlTransaction transaction = con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                    try
                    {
                        using (MySqlCommand cmd1 = new MySqlCommand(sqlTicket.ToString(), con, transaction))
                        {
                            cmd1.CommandType = System.Data.CommandType.Text;
                            cmd1.Parameters.Add("@Id", MySqlDbType.Int32).Value = ticket.Id;
                            cmd1.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = ticket.Fecha;
                            cmd1.Parameters.Add("@IdentidadCliente", MySqlDbType.VarChar, 25).Value = ticket.IdentidadCliente;
                            cmd1.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = ticket.CodigoUsuario;
                            cmd1.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 100).Value = ticket.TipoSporte;
                            cmd1.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 100).Value = ticket.DescripcionSolicitud;
                            cmd1.Parameters.Add("@RespuestaSolicitud", MySqlDbType.VarChar, 100).Value = ticket.RespuestaSolicitud;
                            cmd1.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = ticket.Precio;
                            cmd1.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = ticket.ISV;
                            cmd1.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = ticket.Descuento;
                            cmd1.Parameters.Add("@Total", MySqlDbType.Decimal).Value = ticket.Total;
                            idFactura = Convert.ToInt32(cmd1.ExecuteScalar());
                        }

                        foreach (DetalleTicket detalle in detalles)
                        {
                            using (MySqlCommand cmd2 = new MySqlCommand(sqlDetalle.ToString(), con, transaction))
                            {
                                cmd2.Parameters.Add("@Id", MySqlDbType.Int32).Value = ticket.Id;
                                cmd2.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = ticket.Fecha;
                                cmd2.Parameters.Add("@IdentidadCliente", MySqlDbType.VarChar, 25).Value = ticket.IdentidadCliente;
                                cmd2.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = ticket.CodigoUsuario;
                                cmd2.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 100).Value = ticket.TipoSporte;
                                cmd2.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 100).Value = ticket.DescripcionSolicitud;
                                cmd2.Parameters.Add("@RespuestaSolicitud", MySqlDbType.VarChar, 100).Value = ticket.RespuestaSolicitud;
                                cmd2.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = ticket.Precio;
                                cmd2.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = ticket.ISV;
                                cmd2.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = ticket.Descuento;
                                cmd2.Parameters.Add("@Total", MySqlDbType.Decimal).Value = ticket.Total;
                                idFactura = Convert.ToInt32(cmd2.ExecuteScalar());
                            }

                        }

                        transaction.Commit();
                        inserto = true;
                    }
                    catch (System.Exception)
                    {
                        inserto = false;
                        transaction.Rollback();
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return inserto;
        }


    }
}
