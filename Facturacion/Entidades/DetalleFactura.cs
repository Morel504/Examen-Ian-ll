namespace Entidades
{
    public class DetalleTicket
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        public DetalleTicket()
        {
        }

        public DetalleTicket(int id, int idFactura, string descripcion, decimal precio, int cantidad, decimal total)
        {
            Id = id;
            IdFactura = idFactura;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
            Total = total;
        }
    }
}
