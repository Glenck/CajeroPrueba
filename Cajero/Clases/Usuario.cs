using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Cajero.Clases
{
    public class Usuario
    {
        public string NumeroCuenta { get; set; }
        public string Nombre { get; set; }

        public decimal Saldo { get; set; }

        public string Pin { get; set; } //se definen las propiedades de la clase usuario



        public Usuario() 
        {
            this.NumeroCuenta = NumeroCuenta;
            this.Nombre = Nombre;
            this.Saldo = Saldo;
            this.Pin = Pin;
        }//constructor por defecto de la clase usuario

        public void Depositar() // se define el metodo depositar
        {
            Console.WriteLine("Digite el monto a depositar ");
            decimal Cantidad = decimal.Parse(Console.ReadLine()); // se solicita y se lee la cantidad a depositar
            Usuario.registroMovimientos($"Se depositaron = {Cantidad},{NumeroCuenta}"); // registra el movimiento en el archivo de texto

            if (Cantidad <= 0) // se valida que la cantidad a depositar sea mayor a 0
            {
                Console.WriteLine("El saldo a depositar debe de ser mayor que $0 ");
            }
            else // si la cantidad es valida se realiza el deposito
            {
                Saldo += Cantidad;
                Console.WriteLine($"La cantidad depositada es de {Cantidad}");
                Console.WriteLine($"Su nuevo saldo es {Saldo}");
            }
            Console.ReadKey(true);
        }
        public void Retirar() // se define el metodo retirar
        {
            Console.WriteLine("Digite la Cantidad a retirar");
            decimal Valor = decimal.Parse(Console.ReadLine()); // se solicita y se lee la cantidad a retirar
            Usuario.registroMovimientos($"Se retiraron = {Valor},{NumeroCuenta}");// registra el movimiento en el archivo de texto

            if (Saldo < Valor) // se valida que el saldo sea mayor a la cantidad a retirar
            {
                Console.WriteLine("El saldo insuficiente  ");
            }
            else // si la cantidad es valida se realiza el retiro
            {
                Saldo -= Valor;
                Console.WriteLine($"La cantidad retirada es de {Valor}");
                Console.WriteLine($"Su nuevo saldo es {Saldo}"); // se muestra el nuevo saldo
            }
            Console.ReadKey(true);
        }
        public void VerSaldo() // se define el metodo ver saldo

        {
            Console.WriteLine($"Saldo actual: {Saldo}"); // se muestra el saldo actual

            Console.ReadKey(true);
        }

        public static Usuario iSA(string rutaUsuarios, string comprobarUsuario, string comprobarPin) // metodo para comprobar si el usuario y pin son correctos
        {
            if (File.Exists(rutaUsuarios)) // se valida que el archivo de texto exista
            {
                foreach (string linea in File.ReadAllLines(rutaUsuarios)) // se lee el archivo de texto linea por linea
                {
                    string ln = linea.Trim();
                    string[] datos = linea.Split(',');
                    if (datos.Length < 4) // se valida que la linea tenga los datos necesarios
                    {
                        continue;
                    }
                    string numeroCuenta = datos[0].Trim(); // se asignan los datos a las variables
                    string pin = datos[1].Trim();
                    string nombre = datos[2].Trim();
                    decimal saldo = 0;
                    decimal.TryParse(datos[3].Trim(), out saldo);
                    if (numeroCuenta == comprobarUsuario && pin == comprobarPin) // se valida que el usuario y pin sean correctos
                    {
                        return new Usuario{ NumeroCuenta = numeroCuenta,Pin = pin,Nombre = nombre,Saldo = saldo}; 
                        // si son correctos se retorna un objeto de la clase usuario
                    }
                }
            }
            return null; // Credenciales inválidas o archivo no encontrado  
        }

        public static void registroMovimientos(string mensaje) // metodo para registrar los movimientos en un archivo de texto
        {
            string rutaMovimientos = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Movimientos txt");
            string texto = $"{DateTime.Now}, {mensaje},"; // se crea el texto a registrar con la fecha y hora actual

            File.AppendAllText(rutaMovimientos, texto + Environment.NewLine); // se escribe el texto en el archivo de texto

        }

        public void MostrarMovimiento(string numerocuenta) // metodo para mostrar los ultimos 5 movimientos del usuario
        {
            string rutaMovimientos = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Movimientos txt");
           
            if (!File.Exists(rutaMovimientos)) // se valida que el archivo de texto exista
            {
                Console.WriteLine("No hay movimientos registrados.");
                return;
            }

            string[] lineas = File.ReadAllLines(rutaMovimientos); // se lee el archivo de texto linea por linea

            List<string> movimientosCuenta = new List<string>(); // lista para almacenar los movimientos del usuario

            foreach (string linea in lineas) // se recorre la lista de lineas
            {
                if (linea.Contains(numerocuenta)) // se valida que la linea contenga el numero de cuenta del usuario
                {
                    movimientosCuenta.Add(linea); // si es asi se agrega a la lista de movimientos del usuario
                }
            }
           if(movimientosCuenta.Count == 0) // se valida que la lista de movimientos del usuario no este vacia
            {
                Console.WriteLine($"No hay movimientos registrados para la cuenta ");
                return;
            } 

            var movimientosRecientes = movimientosCuenta.Skip(Math.Max(0,movimientosCuenta.Count -5)); // se obtienen los ultimos 5 movimientos del usuario

            Console.WriteLine("Ultimos 5 movimientos:");
            foreach (string movimiento in movimientosRecientes) // se recorre la lista de movimientos recientes
            {
                Console.WriteLine(movimiento); // se muestra el movimiento
            }


        }
        public void CambiarPin() // metodo para cambiar el pin del usuario
        {
            string rutaUsuarios = ("C:\\Users\\Usuario\\Documents\\Git\\CajeroPrueba\\Archivos txt\\Usuarios.txt");
            if (File.Exists(rutaUsuarios)) // se valida que el archivo de texto exista
            {
                string[] lineas = File.ReadAllLines(rutaUsuarios); // se lee el archivo de texto linea por linea
                for (int i = 0; i < lineas.Length; i++) // se recorre la lista de lineas
                {
                    string[] datos = lineas[i].Split(','); // se separan los datos de la linea
                    if (datos.Length < 4) // se valida que la linea tenga los datos necesarios
                    {
                        continue;
                    }
                    string cuenta = datos[0].Trim(); // se asignan los datos a las variables
                    if (cuenta == NumeroCuenta) // se valida que el numero de cuenta sea igual al del usuario
                    {
                        Console.WriteLine("Digite su nuevo pin");
                        string nuevoPin = Console.ReadLine().Trim(); // se solicita y se lee el nuevo pin
                        int validor = int.Parse(nuevoPin);
                        if (validor > 0) // se valida que el nuevo pin sea mayor a 0000
                        {
                            datos[1] = nuevoPin;
                            lineas[i] = string.Join(",", datos); // se actualiza la linea con el nuevo pin
                            File.WriteAllLines(rutaUsuarios, lineas);
                            this.Pin = nuevoPin; // Actualizar el PIN en la instancia actual
                            Console.WriteLine("Pin cambiado con exito");
                            return;
                        }
                        else // si el nuevo pin no es valido se muestra un mensaje de error
                        {
                            Console.WriteLine("El pin debe ser mayor a 0000");
                            return;
                        }
                        
                    }
                }
                Console.WriteLine("Cuenta no encontrada.");
            }
            else
            {
                Console.WriteLine("El archivo de usuarios no existe.");
            }

        }
    }
    
}