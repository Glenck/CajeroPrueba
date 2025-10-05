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

        public string Pin { get; set; }


        public Usuario()
        {
            this.NumeroCuenta = NumeroCuenta;
            this.Nombre = Nombre;
            this.Saldo = Saldo;
            this.Pin = Pin;
        }

        public void Depositar()
        {
            Console.WriteLine("Digite el monto a depositar ");
            decimal Cantidad = decimal.Parse(Console.ReadLine());
            Usuario.registroMovimientos($"Se depositaron = {Cantidad},{NumeroCuenta}");

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
            Usuario.registroMovimientos($"Se retiraron = {Valor},{NumeroCuenta}");
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


        public static bool IniciarSecion(string rutaUsuarios, string ComprobarUsuario, string ComprobarPin)
        {
            if (File.Exists(rutaUsuarios))
            {
                string[] lineas = File.ReadAllLines(rutaUsuarios);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');

                    if (datos[0] == ComprobarUsuario && datos[1] == ComprobarPin)
                    {
                        return true; // Credenciales válidas
                    }
                }
            }

            return false; // Credenciales inválidas o archivo no encontrado


        }
        public void CargarUsuarios(string rutaUsuarios, string comprobarUsuario, string comprobarPin)
        {


            if (File.Exists(rutaUsuarios))
            {
                string[] lineas = File.ReadAllLines(rutaUsuarios);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length == 4)
                    {

                        string NumeroCuenta = datos[0];
                        string Pin = datos[1];
                        string Nombre = datos[2];
                        decimal Saldo = decimal.Parse(datos[3]);
                        if (comprobarUsuario == NumeroCuenta && comprobarPin == Pin)
                        {

                        }

                    }
                }
            }

        }
        public static void registroMovimientos(string mensaje)
        {
            string rutaMovimientos = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Movimientos txt");

            string texto = $"{DateTime.Now}, {mensaje},";

            File.AppendAllText(rutaMovimientos, texto + Environment.NewLine);

        }

        public static List<string> MostrarMovimiento(string numerocuenta)
        {
            List<string> movimientos = new List<string>();
            string rutaMovimientos = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Movimientos txt");
            if (File.Exists(rutaMovimientos))
            {
                string[] linea = File.ReadAllLines(rutaMovimientos);
                foreach (string s in linea)
                {
                    if (s.Contains($"{numerocuenta}"))
                    {
                        movimientos.Add(s);
                        Console.WriteLine(linea[s]);
                    }

                }
            }

            return movimientos;

        }


    }



}