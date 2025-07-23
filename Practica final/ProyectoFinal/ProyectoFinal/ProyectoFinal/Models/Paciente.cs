using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ProyectoFinal.Models
{
    public class Paciente
    {
        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Cita> Citas { get; set; }
    }
}

    
