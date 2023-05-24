using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Modelo.DAL;
using SimuladorMedidor.Comunicacion;



namespace ServicioComunicacion.Comunicacion
{
    public class ThreadServidor
    {
        public void Ejecutar()
        {
            int puertoDefault = 3000;
            Console.WriteLine("Iniciando servidor. Seleccione el puerto a utilizar (deje en blanco para utilizar el puerto {0}): ", puertoDefault);

            string puertoInput = Console.ReadLine().Trim();
            int puerto;
            if (!string.IsNullOrEmpty(puertoInput))
            {
               if (RevisarDisponibilidad(Int32.Parse(puertoInput)))
                {
                    puerto = Int32.Parse(puertoInput);
                }
               else
                {
                    Console.WriteLine("Puerto {0} ya está en uso, utilizando puerto por defecto {1}.", puertoInput, puertoDefault);
                    puerto = puertoDefault;
                }
            }
            else
            {
                puerto = puertoDefault;
            }

            

            SocketServidor servidor = new SocketServidor(puerto);
            Console.WriteLine("El servidor se ha iniciado en el puerto {0}", puerto);

            if (servidor.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("Esperando cliente....");
                    Socket cliente = servidor.ObtenerCliente();
                    Console.WriteLine("Cliente recibido");
                    ClienteCom clienteCom = new ClienteCom(cliente);

                    ThreadCliente threadCliente = new ThreadCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(threadCliente.ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }
            }
            else
            {
                Console.WriteLine("¡Error! No se pudo iniciar el servidor en el puerto {0}", puerto);
            }
        }


        public bool RevisarDisponibilidad(int puerto)
        {
            bool disponible = true;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == puerto)
                {
                    disponible = false;
                    break;
                }
            }

            return disponible;
        }
    }
}
