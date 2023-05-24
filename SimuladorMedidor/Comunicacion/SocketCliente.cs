using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorMedidor.Comunicacion
{
    public class SocketCliente
    {
        private int puerto;
        private Socket cliente;


        public SocketCliente(int puerto)
        {
            this.puerto = puerto;
        }


        public bool Iniciar()
        {
            try
            {
                this.cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.cliente.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                this.cliente.Listen(10);
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
                this.cliente.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public Socket ObtenerCliente()
        {
            return this.cliente;
        }

    }
}
