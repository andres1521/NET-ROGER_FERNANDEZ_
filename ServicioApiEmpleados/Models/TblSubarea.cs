using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioApiEmpleados.Models
{
    public partial class TblSubarea
    {
        public TblSubarea()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
        }

        public int NumSubareaId { get; set; }
        public string Nombre { get; set; }
        public int NumAreaId { get; set; }

        public virtual TblArea NumArea { get; set; }
        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
    }
}
