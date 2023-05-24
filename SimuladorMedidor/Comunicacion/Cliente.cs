using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorMedidor.Comunicacion
{
    internal class Cliente
    {
        IPHostEntry host;
        IPAddress ipAddress;
        IPEndPoint endpoint;
        Socket socketCliente;
        StreamReader reader;
        StreamWriter writer;
        public Cliente(string ip, int puerto)
        {
            host = Dns.GetHostEntry(ip);
            ipAddress = host.AddressList[1];
            Console.WriteLine(ipAddress.ToString());
            endpoint = new IPEndPoint(ipAddress, puerto);

            socketCliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }

        public void Iniciar()
        {
            socketCliente.Connect(endpoint);
            Stream stream = new NetworkStream(socketCliente);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        public string Enviar(string mensaje)
        {
            writer.WriteLine(mensaje);
            writer.Flush();
            return mensaje;
        }

        public String Leer()
        {

            try
            {
                string mensaje = this.reader.ReadLine().Trim();
                return mensaje;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
