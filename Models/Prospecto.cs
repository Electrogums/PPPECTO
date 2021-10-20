using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ProyectoProspectos.Models
{
    public partial class Prospecto
    {
        public Prospecto()
        {
            Documentos = new HashSet<Documento>();
        }

        public int IdProspecto { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Apellido Paterno")]
        public string PrimerApellido { get; set; }
        [DisplayName("Apellido Materno")]
        public string SegundoApellido { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Cp { get; set; }
        public string Telefono { get; set; }
        public string Rfc { get; set; }
        public int? IdEstatus { get; set; }
        public string Observación { get; set; }

        public virtual CatStatus IdEstatusNavigation { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }
    }
}
