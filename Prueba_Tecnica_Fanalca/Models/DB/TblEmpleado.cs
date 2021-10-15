using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Prueba_Tecnica_Fanalca.Models.DB
{
    public partial class TblEmpleado
    {
        
        public int NumEmpleadoId { get; private set; }

        [Required(ErrorMessage = "Por favor ingrese un Tipo de documento")]
        [Display(Name ="Tipo de Documento")]
        public int NumTipoDocId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un Numero de documento")]
        [Display(Name = "Numero de Documento")]
        public int NumDocumento { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor ingrese el Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Por favor ingrese un Área de la Empresa")]
        [Display(Name = "Área")]
        [Range(1, double.MaxValue, ErrorMessage = "Por favor ingrese un Área de la Empresa")]
        public int NumAreaId { get; set; }
        [Required( ErrorMessage = "Debe ingresar una Sub Área")]
        [Display(Name = "Sub Área")]
        [Range(1, double.MaxValue, ErrorMessage = "Por favor ingrese una Sub área ")]
        public int NumSubareaId { get; set; }

        public virtual TblArea NumArea { get; set; }
        public virtual TblSubarea NumSubarea { get; set; }
        public virtual TblTipoDocumento NumTipoDoc { get; set; }
    }
}
