using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Tarea___Pilares_POO.NewFolder.mini_e_commerce;
using static Tarea___Pilares_POO.NewFolder.mini_e_commerce.Producto;

namespace Tarea___Pilares_POO.NewFolder
{
    internal class mini_e_commerce
    {
        public interface IPago
        {
            void ProcesarPago();
        }
        public abstract class Producto
        {
            public string? Nombre { get; set; }
            public int Precio { get; set; }
            public string? Categoria { get; set; }
            public decimal Descuento { get; set; } = 0;

        }
        public class ProductoFisico : Producto
        {
            public ProductoFisico(string nombre, int precio, string categoria)
            {
                Nombre = nombre;
                Precio = precio;
                Categoria = categoria;
            }

        }
        public class ProductoDigital : Producto
        {
            public ProductoDigital(string nombre, int precio, string categoria)
            {
                Nombre = nombre;
                Precio = precio;
                Categoria = categoria;
            }

        }
        public class PagoConTarjeta : IPago
        {
            private decimal Numerotarjeta { get; set; }
            private decimal SaldoDisponible { get; set; }

            public PagoConTarjeta (decimal numerotarjeta, decimal saldoDisponible)
            {
                Numerotarjeta = numerotarjeta;
                SaldoDisponible = saldoDisponible;
            }
            public void ProcesarPago()
            {
                if (SaldoDisponible > 0)
                {
                    Console.WriteLine("Pago con tarjeta procesado exitosamente.");

                }
                else 
                {
                    Console.WriteLine("Saldo insuficiente en la tarjeta, tarjeta rechazada");
                }
            }
        }

        public class PagoConTransferencia : IPago
        {
            public decimal NumeroDeCuenta { get; private set; }
            public decimal SaldoDisponible { get; private set; }
            public string Banco {  get; set; }

            public PagoConTransferencia (decimal numeroDeCuenta, decimal saldoDisponible, string banco)
            {
                NumeroDeCuenta = numeroDeCuenta;
                SaldoDisponible = saldoDisponible;
                Banco = banco;
            }
            public void ProcesarPago()
            {
                if (SaldoDisponible > 0)
                {
                    Console.WriteLine("La transferencia fue exitosamente realizado.");
                }
                else
                {
                    Console.WriteLine($"La transferencia fue rechadaza por falta de fondo. Contacte con {Banco} para realizar la transferencia.");
                }
            }
        }

        public class PagoConPuntos : IPago
        {
        public decimal PuntosAcumulados { get; set; }
        
        public PagoConPuntos(decimal puntosAcumulado) 
        {
            PuntosAcumulados = puntosAcumulado;
        }
        public void ProcesarPago ()
        {
                if (PuntosAcumulados > 0)
                {
                    Console.WriteLine("Pago realizado con puntos exitosamente.");
                }
                else
                {
                    Console.WriteLine("No tienes puntos suficientes para realizar el pago.");
                }
        }
        }

        public class Cliente
        {
            public string Nombre { get; set; }
            public string Correo { get; set; }

            public Cliente(string nombre, string correo)
            {
                Nombre = nombre;
                Correo = correo;
            }
        }
        public class Carrito
        {
            private List<Producto> productos = new List<Producto>();

            public void AgregarProducto(Producto producto)
            {
                productos.Add(producto);
                Console.WriteLine($"{producto.Nombre} agregado al carrito.");

            }
            public void EliminarProducto(Producto producto)
            {
                productos.Remove(producto);
                Console.WriteLine($"{producto.Nombre} eliminado del carrito.");
            }

            public void MostrarCarrito()
            {
                Console.WriteLine("\n--- Carrito ---");
                foreach (var prod in productos)
                {
                    Console.WriteLine($"{prod.Nombre} - {prod.Categoria} - Q{prod.Precio}");
                }
            }
            public int Total()
            { 
                int total = 0;
                foreach (var producto in productos)
                {
                    total += producto.Precio;
                }
                return total; 
            }

            public List<Producto> Obtenerproductos()
            {
                return productos;
            }

        }

        public class Orden
        {
            public bool Confirmada { get; private set; }
            public Cliente Cliente { get; set; }
            public Carrito Carrito{ get; set;  }

            public Orden(Cliente cliente, Carrito carrito)
            {
                this.Cliente = cliente;
                this.Carrito = carrito;
                this.Confirmada = false;
            }
            public void ConfirmarOrden()
            {
                Confirmada = true;
                Console.WriteLine("Orden confirmada.");
            }

            public void CancelarOrden()
            {
                Confirmada = false;
                Console.WriteLine("Orden cancelada.");
            }

            public void ResumenOrden()
            {
                Console.WriteLine("=== Resumen de Orden ===");
                Console.WriteLine($"Cliente: {Cliente.Nombre} - {Cliente.Correo}");
                Console.WriteLine($"Total a pagar: {Carrito.Total():C}");
                Console.WriteLine("=======================");
            }
        }

    }
}
