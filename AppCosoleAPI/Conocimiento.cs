using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCosoleAPI
{
    public class Conocimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int? TecnicoId {  get; set; }
        public Tecnico Tecnico { get; set; }


        public string Titulo { get; set; }
        public string Area { get; set; }
    }
}
