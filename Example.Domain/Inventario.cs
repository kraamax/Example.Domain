using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain
{
    public class Inventario
    {
        public Inventario(List<ProductoSimple> productos)
        {
            Productos = productos;
        }
        public List<ProductoSimple> Productos { get; private set; }
       
        private ProductoSimple BuscarProducto(string id) {
            foreach (var item in Productos)
            {
                if (item.Id.Equals(id)) return item;
            }
            return null;
        }
        public string RegistrarEntradaProducto(ProductoSimple producto)
        {
            if (producto.Cantidad <= 0) {
                return "La cantidad de la entrada de debe ser mayor a 0";
            }
            var productoEnInventario= BuscarProducto(producto.Id);
            if (productoEnInventario == null) {
                Productos.Add(producto);
                return $"La cantidad del producto {producto.Nombre} es {producto.Cantidad}";
            }
            else
            {
                return ActualizarProductoInventario(producto.Id, producto.Cantidad, true);
            }
        }
        public string RegistrarSalidaProductoSimple(string id, int cantidad)
        {
            if (cantidad <= 0)
            {
                return "La cantidad de la salida de debe ser mayor a 0";
            }
            else
            {
                return ActualizarProductoInventario(id, cantidad, false);
            }

        }
        public string RegistrarSalidaProductoCompuesto(ProductoCompuesto producto)
        {
            string a = "";
            foreach (var item in producto.Descomponer())
            {
                 a=a+"-"+ActualizarProductoInventario(item.Id, item.Cantidad, false);
            }
            Console.WriteLine(a);
            return a;
        }
        public string ActualizarProductoInventario(string id,int cantidad, bool esEntrada ) {
            foreach (var item in Productos)
            {
                if (item.Id.Equals(id)) {
                    return item.ActualizarCantidad(cantidad, esEntrada);
                }
            }
            return "";
        }
        
    }
   
}
