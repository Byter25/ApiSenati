

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCosoleAPI
{
    public class TecnicosProyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int? TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }


        public int? ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }


        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaCese { get; set; }
    }
}