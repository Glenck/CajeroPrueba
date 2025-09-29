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
             // Instancia de la clase Usuario
            string rutaUsuarios = ("C:\\Users\\Usuario\\Documents\\Git\\Cajero\\CajeroPrueba\\Archivos txt\\Usuarios.txt");
            string rutaMovimientos = ("C:\\Users\\Usuario\\Documents\\Git\\Cajero\\CajeroPrueba\\Archivos txt\\Movimientos.txt");
            //defino la ruta del archivo de texto donde se almacenan los usuarios y movimientos



            Usuario usuario = new Usuario() { NumeroCuenta = "1003687336", Nombre = "Fabio Andres", Pin = 2701, Saldo = 10000000 };
                

            
            if (!File.Exists(rutaUsuarios))
            {
                using (StreamWriter tx = File.CreateText(rutaUsuarios))
                {

                    tx.WriteLine($"Cuenta:{usuario.NumeroCuenta}");
                    tx.WriteLine($"Nombre: {usuario.Nombre}");
                    tx.WriteLine($"Pin: {usuario.Pin}");
                    tx.WriteLine($"Saldo: {usuario.Saldo}");
                    tx.WriteLine("------------------------");

                }
                Console.WriteLine("Archivo creado y texto escrito correctamente.");

            }
            else 
            {
                using (StreamWriter tx = File.AppendText(rutaUsuarios))
                {

                    tx.WriteLine($"Cuenta:{usuario.NumeroCuenta}");
                    tx.WriteLine($"Nombre: {usuario.Nombre}");
                    tx.WriteLine($"Pin: {usuario.Pin}");
                    tx.WriteLine($"Saldo: {usuario.Saldo}");
                    tx.WriteLine("------------------------");
                   
                }
                Console.WriteLine("El archivo ya existe. Se ha agregado nuevo usuario.");
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
