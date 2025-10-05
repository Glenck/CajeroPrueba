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

            // Ruta del archivo de texto que contiene los usuarios
            string rutaUsuarios = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Usuarios.txt");
            
            // Solicitar al usuario su nombre de usuario y PIN

            Console.WriteLine("Digite su usuario");
            string ComprobarUsuario = Console.ReadLine().Trim();
            Console.WriteLine();
            Console.WriteLine("Digite su pin");
            string ComprobarPin = Console.ReadLine().Trim();

            Usuario accesoConcedido = Usuario.iSA(rutaUsuarios, ComprobarUsuario, ComprobarPin); 
            // Se llama al metodo iSA para validar el usuario y el pin


            if (accesoConcedido != null)// Si el usuario es valido se le concede acceso

            {

                bool controlador = true;
                while (controlador) // se crea un ciclo para mostrar el menu hasta que el usuario decida salir
                {
                   
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine(":: Bienvenido al cajero automatico ::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine("::::::  Seleccione una opcion  ::::::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine(":: 1. Depositar                    ::");
                    Console.WriteLine(":: 2. Retirar                      ::");
                    Console.WriteLine(":: 3. Consultar saldo              ::");
                    Console.WriteLine(":: 4. Movimientos                  ::");
                    Console.WriteLine(":: 5. Cambiar clave                ::");
                    Console.WriteLine(":: 6. Salir                        ::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");


                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion) // se crea un switch para seleccionar la opcion del menu
                    {

                        case 1:
                            accesoConcedido.Depositar(); // se llama al metodo depositar
                            Console.WriteLine();
                            Console.WriteLine("Oprima cualquier tecla para volver al menu");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;

                        case 2:
                            accesoConcedido.Retirar(); // se llama al metodo retirar
                            Console.WriteLine();
                            Console.WriteLine("Oprima cualquier tecla para volver al menu");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        case 3:
                            accesoConcedido.VerSaldo(); // se llama al metodo ver saldo
                            Console.WriteLine();
                            Console.WriteLine("Oprima cualquier tecla para volver al menu");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        case 4:
                           accesoConcedido.MostrarMovimiento(accesoConcedido.NumeroCuenta); // se llama al metodo mostrar movimientos
                            Console.WriteLine("Oprima cualquier tecla para volver al menu");
                            Console.ReadKey(true);
                            Console.Clear();
                            break;
                        case 5:
                            accesoConcedido.CambiarPin(); // se llama al metodo cambiar pin
                            Console.WriteLine();
                            Console.WriteLine("Oprima cualquier tecla para volver al menu");
                            Console.ReadKey(true);
                            Console.Clear();

                            break;

                        case 6:
                            controlador = false; // se cambia el valor del controlador para salir del ciclo
                            Console.WriteLine("Gracias por usar el cajero automatico");
                            Console.ReadKey(true); // se espera a que el usuario oprima una tecla
                            Console.Clear();
                            break;

                    }
                    
                }

            }
            else
            {
                Console.WriteLine("Acceso denegado. Usuario o PIN incorrecto.");
                //Acceso es denegado
            }

            
            Console.ReadKey(true);

        }

    }


}
