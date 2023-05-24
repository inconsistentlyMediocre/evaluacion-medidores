using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorMedidor.Comunicacion;
using Modelo.DAL;
using Modelo.DTO;


namespace ServicioComunicacion.Comunicacion
{
    public class ThreadCliente
    {
        private ClienteCom clienteCom;
        private IMensajesDAL mensajesDAL = MensajesDALArchivos.GetInstancia();
        public ThreadCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void ejecutar()
        {
            clienteCom.Escribir("Ingrese el número del medidor: ");

            string nroMedidorString = clienteCom.Leer();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd--HH:mm:ss");
            clienteCom.Escribir(" ¿Cuál es el valor del consumo de su medidor? " +
                "\nIngrese el valor en kilowatts por hora (kw/h)");
            string valorConsumoString = clienteCom.Leer();

            
            Mensaje mensaje = new Mensaje()
            {
                NroMedidorInt = Int32.Parse(nroMedidorString),
                Fecha = fecha,
                ValorConsumoFloat = float.Parse(valorConsumoString)
            };
            lock (mensajesDAL)
            {
                mensajesDAL.AgregarMensaje(mensaje);
            }
            
            clienteCom.Desconectar();
        }
    }
}
