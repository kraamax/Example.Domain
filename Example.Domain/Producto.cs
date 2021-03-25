using System;

namespace Example.Domain
{
    public abstract class Producto
    {
        public Producto(string id, decimal precio, decimal costo, int cantidad, string nombre)
        {
            Id = id;
            Precio = precio;
            Costo = costo;
            Cantidad = cantidad;
            Nombre = nombre;

        }
        public string Id { get; set; }
        public decimal Precio { get; private set; }
        public decimal Costo { get; private set; }
        public int Cantidad { get; protected set; }
        public string Nombre { get; private set; }
        public abstract void GetCantidad();
        public abstract string ActualizarCantidad(int valor, bool esEntrada);

    }
}
