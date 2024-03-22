using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppCosoleAPI
{
    public class Tecnico
    {
        //ESTABLECEMOS ID COMO LLAVE PRIMARIA
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        //CREAMOS LA RELACION CON LA TABLA EMPRESA
        //ESTABLECEMOS QUE LA RELACION ADMITA NULL
        //PARA EVITAR LA CREACION DEL ONDELET EN LA MIGRACION
        public int? EmpresaId { get; set; }
        //CREAMOS LA PROPIEDAD DEL TIPO DE LA TABLA RELACIONADA
        //PARA PDOER NAVEGARLA 
        public Empresa Empresa{ get; set; }

        //CREAMOS LA RELACION CON LA TABLA CAREGORIA
        public int? CategoriaId { get; set; }
        public Categoria Categoria {  set; get; }


        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
