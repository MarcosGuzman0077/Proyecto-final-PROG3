using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Cita
    {
        
            public int CitaID { get; set; }

            public int PacienteID { get; set; }
            public virtual Paciente Paciente { get; set; }

            public DateTime Fecha { get; set; }
            public TimeSpan Hora { get; set; }

            public int ServicioID { get; set; }
            public virtual Servicio Servicio { get; set; }

            public int TerapeutaID { get; set; }
            public virtual Terapeuta Terapeuta { get; set; }

            public TimeSpan Duracion => TimeSpan.FromMinutes(Servicio?.DuracionMinutos ?? 0);

            public string Estado
            {
                get
                {
                    var inicio = Fecha + Hora;
                    var fin = inicio + Duracion;
                    var ahora = DateTime.Now;

                    if (ahora < inicio) return "Vigente";
                    else if (ahora >= inicio && ahora <= fin) return "En proceso";
                    else return "Finalizado";
                }
            }

            public string TiempoRestante
            {
                get
                {
                    var inicio = Fecha + Hora;
                    var restante = inicio - DateTime.Now;
                    return restante.TotalSeconds > 0 ? $"{restante.Days} días, {restante.Hours} horas" : "0";
                }
            }
        }

    }
