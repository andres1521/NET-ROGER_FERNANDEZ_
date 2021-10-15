using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prueba_Tecnica_Fanalca.Models.DB
{
    public partial class TblArea
    {
        public TblArea()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
            TblSubareas = new HashSet<TblSubarea>();
        }

        public int NumAreaId { get; set; }
        [Required]
        [Display(Name = "Nombre de Área")]
        public string Nombre { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
        public virtual ICollection<TblSubarea> TblSubareas { get; set; }
    }
}
