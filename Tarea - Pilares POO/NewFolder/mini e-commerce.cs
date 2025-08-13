using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
            public string Nombre { get; set; }
            public int Precio { get; set; }
            public string Categoria { get; set; }
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
        }
        public PagoConPuntos(decimal puntosAcumulados) 
        {
            PuntosAcumulados = puntosAcumulados;
        }
        void ProcesarPago ()
        { 
        }
    }
}
