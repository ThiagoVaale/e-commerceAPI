using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domine.Entities
{
    public class DollarRate
    {
        public decimal compra { get; set; }

        public decimal venta { get; set; }
        public DateTime fechaActualizacion { get; set; }
    }
}
