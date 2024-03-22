using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppCosoleAPI
{
    public class Categoria
    {
        //ESTABLECEMOS EL CAMPO ID COMO LLAVE PRIMARIA
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
