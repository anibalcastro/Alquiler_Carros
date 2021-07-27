using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class ObjAlquiler : ObjUsuarios 
    {
        public string placa { set; get; }
        public int año { set; get; }
        public string marca { set; get; }
        public string modelo { set; get; }
        public string estilo { set; get; }
        public string color { set; get; }
        public string silla { set; get; }
        public string gps { set; get; }
        public int dias { set; get; }
        public int monto_pagar { set; get; }
        public DateTime fecha_retiro { set; get; }
        public DateTime fecha_devolucion { set; get; }

    }
}
