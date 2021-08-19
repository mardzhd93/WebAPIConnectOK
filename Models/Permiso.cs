using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIConnectOK.Models
{
    public class Permiso
    {
        [Key]
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaPermiso { get; set; }
    }
}
