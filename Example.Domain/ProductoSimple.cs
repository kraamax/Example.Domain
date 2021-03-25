using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Example.Domain
{
    public class ProductoSimple : Producto
    {
        public ProductoSimple(string id, decimal precio, decimal costo, int cantidad, string nombre) : base(id,  cantidad, nombre, precio)
        {
            Costo = costo;
        }

        public  string ActualizarCantidad(int valor, bool esEntrada)
        {
            Cantidad = esEntrada ? Cantidad + valor : Cantidad - valor;
            return $"La cantidad del producto {Nombre} es {Cantidad}";
        }

       
      
    }
}
