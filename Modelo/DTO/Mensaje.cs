using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTO
{
    public class Mensaje
    {
        private int nroMedidorInt;
        private string nroMedidorString;
        private string fecha;
        private float valorConsumoFloat;
        private string valorConsumoString;


        public int NroMedidorInt { get => nroMedidorInt; set => nroMedidorInt = value; }
        public string NroMedidorString { get => nroMedidorString; set => nroMedidorString = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string ValorConsumoString { get => valorConsumoString; set => valorConsumoString = value; }
        public float ValorConsumoFloat { get => valorConsumoFloat; set => valorConsumoFloat = value; }

        public override string ToString()
        {

            return NroMedidorString + "|" + Fecha + "|" + ValorConsumoString;
        }
    }
}