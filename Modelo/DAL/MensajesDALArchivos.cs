using Modelo.DTO;
using Modelo.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DAL
{
    public class MensajesDALArchivos : IMensajesDAL
    {

        private MensajesDALArchivos() { }


        private static MensajesDALArchivos instancia;

        public static IMensajesDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new MensajesDALArchivos();
            }
            return instancia;
        }



        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";
        public void AgregarMensaje(Mensaje mensaje)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(archivo, true))
                {
                    write.WriteLine(mensaje.NroMedidorInt + "|" + mensaje.Fecha + "|" + mensaje.ValorConsumoFloat + " kw/h");
                    write.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<Mensaje> ObtenerMensajes()
        {
            List<Mensaje> lista = new List<Mensaje>();
            try
            {
                using (StreamReader read = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = read.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split('|');
                            Mensaje mensaje = new Mensaje()
                            {
                                NroMedidorString = arr[0],
                                Fecha = arr[1],
                                ValorConsumoString = arr[2]
                            };
                            lista.Add(mensaje);
                        }

                    } while (texto != null);
                }

            }
            catch (Exception ex)
            {
                lista = null;
            }
            return lista;
        }


    }
}