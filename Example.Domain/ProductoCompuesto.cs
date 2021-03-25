using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Domain
{
    public class ProductoCompuesto : Producto
    {
        public decimal Precio { get; private set; }
        public decimal Costo { get; private set; }
        public ProductoCompuesto(string id, decimal precio, decimal costo, int cantidad, string nombre, List<Producto> productos) : base(id, cantidad, nombre)
        {
            Productos = productos;
        }

        public List<Producto> Productos { get; private set; }

        public  string ActualizarCantidad(int valor, bool esEntrada, List<Producto> productosInventario)
        {
            Cantidad = Cantidad + valor;
            return "";
        }

        public List<ProductoSimple> Descomponer()
        {
            List<ProductoSimple> pSimple = new List<ProductoSimple>();
            foreach (var item in Productos)
            {
                if (item.GetType().Equals("Example.Domain.ProductoCompuesto"))
                {
                    var newItem = (ProductoCompuesto)item;
                    foreach (var p in newItem.Descomponer())
                    {
                        pSimple.Add(p);
                    }
                }
                else
                {
                        pSimple.Add((ProductoSimple)item);
                    Console.WriteLine(item.GetType());
                }
            }
            return pSimple;
        }
        
        
    }
}
