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
        public void NoPuedeRegitrarEntradaDeProductosConCantidadMenorOIgualACero()
        {
            Inventario inventario = new Inventario(new List<ProductoSimple>());
            var producto = new ProductoSimple("123a", 1500, 1000, 0, "lechuga");
            inventario.RegistrarEntradaProducto(producto);
            var resultado = inventario.RegistrarEntradaProducto(producto);
            Assert.AreEqual("La cantidad de la entrada de debe ser mayor a 0", resultado);
        }
        /*
         COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS 
        CRITERIOS DE ACEPTACIÓN
           2. La cantidad de la entrada se le aumentará a la cantidad existente del producto
        Dado un producto simple con id=123a, nombre=lechuga, cantidad=2, costo=1000, precio=1500
        cuando se va a registrar la entrada de 2 unidades mas
        entonces mostrara el mensaje la cantidad del producto lechuga es 4
             */
        [Test]
        public void PuedoSumarCantidadAUnProducto()
        {
            Inventario inventario = new Inventario(new List<ProductoSimple>());
            var producto = new ProductoSimple("123a", 1500, 1000, 2, "lechuga");
            inventario.RegistrarEntradaProducto(producto);
            var resultado = inventario.RegistrarEntradaProducto(producto);
            Assert.AreEqual("La cantidad del producto lechuga es 4", resultado);
        }
        /* COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS
         CRITERIOS DE ACEPTACIÓN
         La cantidad de la salida de debe ser mayor a 0
         Dado un producto simple con id=123a, nombre=lechuga, cantidad=4, costo=1000, precio=1500
         cuando se va a registrar la salida de 0 unidades 
         entonces mostrara el mensaje la cantidad del producto lechuga es 2
        */
        [Test]
        public void NoPuedoRegistrarUnaSalidaDeProductoConCantidadMenorOIgualACero()
        {
            Inventario inventario = new Inventario(new List<ProductoSimple>());
            var producto = new ProductoSimple("123a", 1500, 1000, 4, "lechuga");
            inventario.RegistrarEntradaProducto(producto);
            var productoSalida = new ProductoSimple("123a", 1500, 1000, 0, "lechuga");
            var resultado = inventario.RegistrarSalidaProductoSimple("123a",0);
            Assert.AreEqual("La cantidad de la salida de debe ser mayor a 0", resultado);
        }
        /* COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS
         CRITERIOS DE ACEPTACIÓN
         2. En caso de un producto sencillo la cantidad de la salida se le disminuirá a la cantidad existente del producto.
         Dado un producto simple con id=123a, nombre=lechuga, cantidad=4, costo=1000, precio=1500
         cuando se va a registrar la salida de 2 unidades 
         entonces mostrara el mensaje la cantidad del producto lechuga es 2
        */
        [Test]
        public void TengoQueDisminuirLaCantidadDelProductoExistenteCuandoRegistroLaSalida()
        {
            Inventario inventario = new Inventario(new List<ProductoSimple>());
            var producto = new ProductoSimple("123a", 1500, 1000, 4, "lechuga");
            inventario.RegistrarEntradaProducto(producto);
            var resultado = inventario.RegistrarSalidaProductoSimple("123a",2);
            Assert.AreEqual("La cantidad del producto lechuga es 2", resultado);
        }
        //producto compuesto
        [Test]
         public void Test4()
         {
             Inventario inventario = new Inventario(new List<ProductoSimple>());
             var producto = new ProductoSimple("123a", 1500, 1000, 4, "lechuga");
             var producto2 = new ProductoSimple("123b", 1500, 1000, 4, "tomate");
             inventario.RegistrarEntradaProducto(producto);
             inventario.RegistrarEntradaProducto(producto2);
             List<Producto> IngredientesEnsalada = new List<Producto>();
             var tomate= new ProductoSimple("123a", 1500, 1000, 2, "tomate");
             var lechuga = new ProductoSimple("123b", 1500, 1000, 2, "lechuga");
             IngredientesEnsalada.Add(tomate);
             IngredientesEnsalada.Add(lechuga);
             var ensalada = new ProductoCompuesto("123c", 4000, 2000, 1, "Ensalada", IngredientesEnsalada);
             //inventario.RegistrarSalidaProductoCompuesto(combo);
             var resultado = inventario.RegistrarSalidaProductoCompuesto(ensalada);
             Assert.AreEqual("La cantidad del producto lechuga es 2", resultado);
         }

    }
}