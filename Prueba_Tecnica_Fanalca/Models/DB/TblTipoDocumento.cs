using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prueba_Tecnica_Fanalca.Models.DB
{
    public partial class TblTipoDocumento
    {
        public TblTipoDocumento()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
        }

        public int NumTipoDocId { get; set; }
        [Required]
        [Display(Name = "Codigo de tipo Identificacion")]
        public string TipoIdentificacion { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
    }
}
