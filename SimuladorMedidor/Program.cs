using SimuladorMedidor.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SimuladorMedidor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int puertoDefault = 3000;
            Console.WriteLine("Conectándose al servidor. Seleccione el puerto a utilizar (deje en blanco para utilizar el puerto {0}): ", puertoDefault);

            string puertoInput = Console.ReadLine().Trim();
            int puerto;
            if (!string.IsNullOrEmpty(puertoInput))
            {
                puerto = Int32.Parse(puertoInput);
            }
            else
            {
                puerto = puertoDefault;
            }

            Cliente cliente = new Cliente(ip, puerto);
            cliente.Iniciar();

            while (true)
            {
                string respuesta = cliente.Leer();
                Console.WriteLine(respuesta);
                string mensaje = cliente.Enviar(Console.ReadLine());
            }
        }
    }
}
