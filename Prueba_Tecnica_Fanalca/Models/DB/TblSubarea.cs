using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prueba_Tecnica_Fanalca.Models.DB
{
    public partial class TblSubarea
    {
        public TblSubarea()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
        }

        public int NumSubareaId { get; set; }
        [Required]
        [Display(Name = "Nombre de Sub Área")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Nombre de Área")]
        public int NumAreaId { get; set; }

        public virtual TblArea NumArea { get; set; }
        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
    }
}
