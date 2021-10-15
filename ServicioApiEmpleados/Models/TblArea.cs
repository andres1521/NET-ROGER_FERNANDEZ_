using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioApiEmpleados.Models
{
    public partial class TblArea
    {
        public TblArea()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
            TblSubareas = new HashSet<TblSubarea>();
        }

        public int NumAreaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
        public virtual ICollection<TblSubarea> TblSubareas { get; set; }
    }
}
