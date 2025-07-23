using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Servicio
    {
        
            public int ServicioID { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int DuracionMinutos { get; set; }

            public virtual ICollection<Cita> Citas { get; set; }
        }

    }
