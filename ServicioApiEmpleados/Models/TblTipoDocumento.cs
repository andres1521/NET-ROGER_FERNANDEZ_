using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioApiEmpleados.Models
{
    public partial class TblTipoDocumento
    {
        public TblTipoDocumento()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
        }

        public int NumTipoDocId { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
    }
}
