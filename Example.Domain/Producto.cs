using System;

namespace Example.Domain
{
    public abstract class Producto
    {
        public Producto(string id, int cantidad, string nombre)
        {
            Id = id;
            Cantidad = cantidad;
            Nombre = nombre;

        }
        public string Id { get; set; }
       
        public int Cantidad { get; protected set; }
        public string Nombre { get; private set; }

    }
}
