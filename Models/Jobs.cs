using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TecolocoClient.Models
{
    public class Jobs
    {
        [Key]
        public string JobID { get; set; }
        [Required(ErrorMessage = "Ingrese un job de al menos 3 caracteres."), MinLength(3)]
        public string JobName { get; set; }
        [Required(ErrorMessage = "Ingrese un titulo de al menos 3 caracteres"), MinLength(3)]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Ingrese una descripción de al menos 20 caracteres."), MinLength(20)]
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha válida."), DataType(DataType.Date)]
        public DateTime ExpiresAt { get; set; }

    }
}