using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Terapeuta
    {
        
            public int TerapeutaID { get; set; }
            public string Nombre { get; set; }

            public virtual ICollection<Cita> Citas { get; set; }
        }

    }
