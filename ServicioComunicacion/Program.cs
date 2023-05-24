using ServicioComunicacion.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioComunicacion
{
    internal class Program
    {

        // Menu Principal
        static bool Menu()
        {
            bool continuar = true;
            
            return continuar;

        }

        static void Main(string[] args)
        {
            ThreadServidor threadServidor = new ThreadServidor();
            Thread t = new Thread(new ThreadStart(threadServidor.Ejecutar));
            t.Start();

        }


        // TO-DO: Mostar datos de los medidores
    }
}
