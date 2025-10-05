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
            string rutaUsuarios = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Usuarios.txt");
            string rutaMovimientos = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Movimientos txt");
           // Usuario usuario = new Usuario();

            //List<Usuario> ListaUsurios = CargarUsuarios(rutaUsuarios);
            
            //defino la ruta del archivo de texto donde se almacenan los usuarios y movimientos
 
                 
            
            Console.WriteLine("Digite su usuario");
            string ComprobarUsuario = Console.ReadLine().Trim();
            Console.WriteLine();
            Console.WriteLine("Digite su pin");
            string ComprobarPin = Console.ReadLine().Trim();

            Usuario accesoConcedido = iSA (rutaUsuarios, ComprobarUsuario,  ComprobarPin);


            if (accesoConcedido != null)
       
            {
                //List<Usuario> listaUsuarios = CargarUsuarios(rutaUsuarios);

                bool controlador = true;
                while (controlador)
                {
                    Console.Clear();
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine(":: Bienvenido al cajero automatico ::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine("::::::  Seleccione una opcion  ::::::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine(":: 1. Depositar                    ::");
                    Console.WriteLine(":: 2. Retirar                      ::");
                    Console.WriteLine(":: 3. Consultar saldo              ::");
                    Console.WriteLine(":: 4. Movimientos                  ::");
                    Console.WriteLine(":: 5. Salir                        ::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");
                    Console.WriteLine(":::::::::::::::::::::::::::::::::::::");


                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {

                        case 1:
                            accesoConcedido.Depositar();
                            break;

                        case 2:
                            accesoConcedido.Retirar();
                            break;
                        case 3:
                            accesoConcedido.VerSaldo();
                            break;
                        case 4:
                            List<string> usuarios = Usuario.MostrarMovimiento(  accesoConcedido.NumeroCuenta);
                            break;

                        case 5:
                            controlador = false;
                            break;




                    }
                }
              
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Acceso denegado. Usuario o PIN incorrecto.");
                accesoConcedido = null; // Salir del programa si el acceso es denegado
            }

            Console.ReadKey(true);

        }
        
      
        
        }

            
}
