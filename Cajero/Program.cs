using Cajero.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cajero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Digite el monto de la cuenta");
            usuario.Saldo = decimal.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Digite el monto a depositar ");
            decimal Cantidad = decimal.Parse(Console.ReadLine());
            usuario.Depositar(Cantidad);
            Console.WriteLine(usuario.Saldo);

            Console.WriteLine("Digite la Cantidad a retirar");
            decimal valor = decimal.Parse(Console.ReadLine());
            Console.WriteLine();
            usuario.Retirar(valor);
            Console.WriteLine();
            





            Console.ReadKey(true);

            
            

        }
    }
}
