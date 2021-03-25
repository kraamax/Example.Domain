using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain
{
    public class ProductoCompuesto : Producto
    {
        public ProductoCompuesto(string id, decimal precio, decimal costo, int cantidad, string nombre, List<Producto> productos) : base(id, precio, costo, cantidad, nombre)
        {
            Productos = productos;
        }

        public List<Producto> Productos { get; private set; }

        public override string ActualizarCantidad(int valor, bool esEntrada)
        {
            Cantidad = Cantidad + valor;
         
            return a;
        }

        public override void GetCantidad()
        {
            throw new NotImplementedException();
        }

        
    }
}
