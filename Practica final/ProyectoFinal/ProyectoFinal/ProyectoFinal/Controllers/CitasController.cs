using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class CitasController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Paciente).Include(c => c.Servicio).Include(c => c.Terapeuta);
            return View(citas.ToList());
        }

        // MÉTODO PARA EXPORTAR A CSV
        public ActionResult ExportarCSV()
        {
            var citas = db.Citas.Include(c => c.Paciente).Include(c => c.Servicio).Include(c => c.Terapeuta).ToList();
            var sb = new StringBuilder();
            sb.AppendLine("ID,Paciente,Servicio,Terapeuta,Fecha,Hora,Duración,Estado,Días y horas restantes");

            foreach (var c in citas)
            {
                sb.AppendLine($"{c.CitaID},{c.Paciente.Nombre},{c.Servicio.Nombre},{c.Terapeuta.Nombre},{c.Fecha.ToShortDateString()},{c.Hora},{c.Duracion},{c.Estado},{c.TiempoRestante}");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Citas.csv");
        }

        // Resto de tus métodos: Create, Edit, Delete, etc.

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

