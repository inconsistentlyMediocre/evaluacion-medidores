using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServicioComunicacion.Comunicacion
{
    public class SocketServidor
    {
        private int puerto;
        private Socket servidor;


        public SocketServidor(int puerto)
        {
            this.puerto = puerto;
        }


        public bool Iniciar()
        {
            try
            {
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                this.servidor.Listen(10);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void Cerrar()
        {
            try
            {
                this.servidor.Close();
            }
            catch (Exception ex)
            {

            }
        }


        public Socket ObtenerCliente()
        {
            return this.servidor.Accept();
        }
    }
}
