using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioApiEmpleados.Models
{
    public partial class TblEmpleado
    {
        public int NumEmpleadoId { get; set; }
        public int NumTipoDocId { get; set; }
        public int NumDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NumAreaId { get; set; }
        public int NumSubareaId { get; set; }

        public virtual TblArea NumArea { get; set; }
        public virtual TblSubarea NumSubarea { get; set; }
        public virtual TblTipoDocumento NumTipoDoc { get; set; }
    }
}
