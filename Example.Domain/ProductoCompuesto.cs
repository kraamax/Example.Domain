using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Example.Domain
{
    public class ProductoCompuesto : Producto
    {
        
        public List<Producto> Productos { get; private set; }
       
        public ProductoCompuesto(string id, decimal precio, int cantidad, string nombre, List<Producto> productos) : base(id, cantidad, nombre,precio)
        {
            Productos = productos;
            Costo = CalcularCosto();
        }


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
                if (item.GetType().Equals(typeof(ProductoCompuesto)))
                {
                    Console.WriteLine("Aca Stoy");
                    var newItem = (ProductoCompuesto)item;
                    foreach (var p in newItem.Descomponer())
                    {
                        pSimple.Add(p);
                    }
                }
                else
                {
                        pSimple.Add((ProductoSimple)item);
                }
            }
            return pSimple;
        }
        public decimal CalcularCosto()
        {
            decimal costo = 0;
            foreach (var item in Productos)
            {
                if (item.GetType().Equals(typeof(ProductoCompuesto)))
                {
                    var newItem = (ProductoCompuesto)item;
                    foreach (var p in newItem.Descomponer())
                    {
                        Console.WriteLine(p.Costo);
                        costo = costo +(p.Costo*p.Cantidad);
                    }
                    Console.WriteLine(Costo);
                }
                else
                {
                    Console.WriteLine(item.Costo);
                    costo = costo + (item.Costo * item.Cantidad); 
                }
            }
            return costo;
        }

    }
}
