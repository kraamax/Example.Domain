using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain
{
    public class Inventario
    {
        public Inventario(List<Producto> productos)
        {
            Productos = productos;
        }
        public List<Producto> Productos { get; private set; }
        public void NewProductoAdd(Producto producto)
        {
           
            Productos.Add(producto);
        }
        private Producto BuscarProducto(string id) {
            foreach (var item in Productos)
            {
                if (item.Id.Equals(id)) return item;
            }
            return null;
        }
        public string IngresarProducto(string id, int cantidad)
        {
            if (cantidad <= 0) {
                return "La cantidad de la entrada de debe ser mayor a 0";
            }
            var producto = BuscarProducto(id);
            return producto.ActualizarCantidad(cantidad,true);
        }
        public string SacarProducto(string id, int cantidad) {
            if (cantidad <= 0)
            {
                return "La cantidad de la salida de debe ser mayor a 0";
            }
            var producto = BuscarProducto(id);
            if (producto.GetType().Equals("Example.Domain.ProductoCompuesto"))
            {
            }

                return producto.ActualizarCantidad(cantidad, false);
        }
    }
   
}
