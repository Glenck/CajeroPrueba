using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cajero.Clases
{
    internal class Usuario
    {
        public string NumeroCuenta { get; set; }
        public string Nombre { get; set; }

        public decimal Saldo { get; set; }

        public int Pin { get; set; }

    


        public void Depositar()
        {
            Console.WriteLine("Digite el monto a depositar ");
            decimal Cantidad = decimal.Parse(Console.ReadLine());

            if (Cantidad <= 0)
            {
                Console.WriteLine("El saldo a depositar debe de ser mayor que $0 ");
            }
            else
            {
                Saldo += Cantidad;
                Console.WriteLine($"La cantidad depositada es de {Cantidad}");
                Console.WriteLine($"Su nuevo saldo es {Saldo}");
            }
            Console.ReadKey(true);
        }
        public void Retirar()
        {
            Console.WriteLine("Digite la Cantidad a retirar");
            decimal Valor = decimal.Parse(Console.ReadLine());
            if (Saldo < Valor)
            {
                Console.WriteLine("El saldo isuficiente  ");
            }
            else
            {
                Saldo -= Valor;
                Console.WriteLine($"La cantidad retirada es de {Valor}");
                Console.WriteLine($"Su nuevo saldo es {Saldo}");
            }
            Console.ReadKey(true);
        }
        public void VerSaldo()
        {
            Console.WriteLine($"Saldo actual: {Saldo}");

            Console.ReadKey(true);

        }
    }







}

