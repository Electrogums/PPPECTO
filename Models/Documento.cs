using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProspectos.Models
{
    public partial class Documento
    {
        public int IdDocumento { get; set; }
        public int? IdProspecto { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public virtual Prospecto IdProspectoNavigation { get; set; }
    }
}
