using NUnit.Framework;
using Example.Domain;
using System.Collections.Generic;

namespace Example.Domain.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /*
        COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
       CRITERIOS DE ACEPTACIÓN
       1. La cantidad de la entrada de debe ser mayor a 0
       Dado un producto simple con id=123a, nombre=lechuga, cantidad=2, costo=1000, precio=1500
       cuando se van a agregas 0 unidades mas 
       entonces mostrara el mensaje La cantidad de la entrada de debe ser mayor a 0
            */
        [Test]
        public void Test1()
        {
            Inventario inventario = new Inventario(new List<Producto>());
            Producto producto = new ProductoSimple("123a", 1500, 1000, 2, "lechuga");
            var resultado = inventario.IngresarProducto("123a",0);
            Assert.AreEqual("La cantidad de la entrada de debe ser mayor a 0", resultado);
        }
        /*
         COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
        CRITERIOS DE ACEPTACIÓN
        1. La cantidad de la entrada de debe ser mayor a 0
        Dado un producto simple con id=123a, nombre=lechuga, cantidad=2, costo=1000, precio=1500
        cuando se va a registrar la entrada de 2 unidades mas
        entonces mostrara el mensaje la cantidad del producto lechuga es 4
             */
        [Test]
        public void Test2()
        {
            Inventario inventario = new Inventario(new List<Producto>());
            Producto producto = new ProductoSimple("123a", 1500, 1000, 2, "lechuga");
            inventario.NewProductoAdd(producto);
            var resultado = inventario.IngresarProducto("123a", 2);
            Assert.AreEqual("La cantidad del producto lechuga es 4", resultado);
        }
        /* COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS
         CRITERIOS DE ACEPTACIÓN
         La cantidad de la salida de debe ser mayor a 0
                 Dado un producto simple con id=123a, nombre=lechuga, cantidad=4, costo=1000, precio=1500
         cuando se va a registrar la salida de 2 unidades 
         entonces mostrara el mensaje la cantidad del producto lechuga es 2
 */
        [Test]
        public void Test3()
        {
            Inventario inventario = new Inventario(new List<Producto>());
            Producto producto = new ProductoSimple("123a", 1500, 1000, 4, "lechuga");
            inventario.NewProductoAdd(producto);
            var resultado = inventario.SacarProducto("123a", 2);
            Assert.AreEqual("La cantidad del producto lechuga es 2", resultado);
        }
        //producto compuesto
        [Test]
        public void Test4()
        {
            Inventario inventario = new Inventario(new List<Producto>());
            Producto producto = new ProductoSimple("123a", 1500, 1000, 4, "lechuga");
            Producto producto2 = new ProductoSimple("123b", 1500, 1000, 4, "tomate");
            inventario.NewProductoAdd(producto);
            inventario.NewProductoAdd(producto2);
            List<Producto> productos = new List<Producto>();
            var producto3= new ProductoSimple("123a", 1500, 1000, 1, "tomate");
            var producto4 = new ProductoSimple("123b", 1500, 1000, 1, "lechuga");
            productos.Add(producto3);
            productos.Add(producto4);
            Producto productoC = new ProductoCompuesto("123c", 4000, 2000, 1, "Ensalada", productos);
            inventario.NewProductoAdd(productoC);
            var resultado = inventario.IngresarProducto("123c", 1);
            Assert.AreEqual("La cantidad del producto lechuga es 2", resultado);
        }

    }
}