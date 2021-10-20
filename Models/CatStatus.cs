using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProspectos.Models
{
    public partial class CatStatus
    {
        public CatStatus()
        {
            Prospectos = new HashSet<Prospecto>();
        }

        public int IdEstatus { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Prospecto> Prospectos { get; set; }
    }
}
