using Cajero.Clases;
using System;
using System.IO;
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
            Usuario usuario = new Usuario(); // Instancia de la clase Usuario
            string rutaUsuarios = ("C:\\Users\\Usuario\\Documents\\Git\\Cajero\\CajeroPrueba\\Archivos txt\\Usuarios.txt");
            string rutaMovimientos = ("C:\\Users\\Usuario\\Documents\\Git\\Cajero\\CajeroPrueba\\Archivos txt\\Movimientos.txt");
            //defino la ruta del archivo de texto donde se almacenan los usuarios y movimientos

            List<Usuario> listaUsuarios = new List<Usuario>()// Lista de usuarios predefinidos
            {
                new Usuario(){ NumeroCuenta = "1003687336", Nombre = "Fabio Andres", pin = 2701, Saldo = 10000000 },
                new Usuario(){ NumeroCuenta = "1234567890", Nombre = "Daniel Hernandez", pin = 0987, Saldo = 2000000 },
                new Usuario(){ NumeroCuenta = "1233492717", Nombre = "Aswin Niño", pin = 4562, Saldo = 15000000 },
            };

            using (StreamWriter tx = new StreamWriter(rutaUsuarios))
            {
                foreach (Usuario i in listaUsuarios)
                {
                    tx.WriteLine($"Cuenta:{usuario.NumeroCuenta}");
                    tx.WriteLine($"Nombre: {usuario.Nombre}");
                    tx.WriteLine($"Pin: {usuario.pin}");
                    tx.WriteLine($"Saldo: {usuario.Saldo}");
                    tx.WriteLine("------------------------");
                }
            }
            










































            /*
            bool contrlador = true ;
            while (contrlador)
            {
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                Console.WriteLine(":: Bienvenido al cajero automatico ::");
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("::::::  Seleccione una opcion  ::::::");
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::");

                /*
                Console.WriteLine(":: 1. Ingresar                     ::");
                Console.WriteLine(":: 2. Salir                        ::");
                
                Console.WriteLine(":: 1. Depositar                    ::");
                Console.WriteLine(":: 2. Retirar                      ::");
                Console.WriteLine(":: 3. Consultar saldo              ::");
                Console.WriteLine(":: 4. Movimientos                  ::");
                Console.WriteLine(":: 5. Salir                        ::");

                int opcion = int.Parse(Console.ReadLine());

                switch (opcion) {
                    case 1:
                        usuario.Depositar();
                        break;

                        case 2:
                        usuario.Retirar();
                        break;
                        case 3:
                      usuario.VerSaldo();
                        break;
                        case 5:
                        contrlador = false;
                        break;




                }
   
                       */
        }

        }
    }
}
