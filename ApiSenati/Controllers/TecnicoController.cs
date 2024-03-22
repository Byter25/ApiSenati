using AppCosoleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSenati.Controllers
{
    // Se define la ruta base para el controlador usando atributos de enrutamiento.
    [Route("api/[controller]")]

    // Se indica que la clase es un controlador de API.
    [ApiController]
    public class TecnicoController : Controller
    {
        // Se declara una variable privada para el contexto de la base de datos.
        private SenatiContext _senatiContext;

        // Constructor que inyecta el contexto de la base de datos.
        public TecnicoController(SenatiContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        // Método HTTP GET para obtener la lista de técnicos.
        [HttpGet]
        [Route("Get")]
        public List<Tecnico> Get()
        {
            // Retorna la lista de técnicos convertida a una lista.
            return _senatiContext.Tecnicos.ToList();
        }

        // Método HTTP POST para agregar un nuevo técnico.
        [HttpPost]
        [Route("AddTecnico")]
        public bool AddAlumno([FromBody] Tecnico tecnico)
        {
            try
            {
                // Agrega el técnico al contexto y guarda los cambios.
                _senatiContext.Tecnicos.Add(tecnico);
                _senatiContext.SaveChanges();
                return true; // Retorna verdadero si la operación es exitosa.
            }
            catch (Exception ex)
            {
                return false; // Retorna falso si ocurre una excepción.
            }
        }

        // Método HTTP POST para actualizar un técnico existente.
        [HttpPost]
        [Route("UpdateTecnico")]
        public bool UpdateAlumno([FromBody] Tecnico tecnico)
        {
            try
            {
                // Marca el estado del técnico como modificado y guarda los cambios.
                _senatiContext.Entry(tecnico).State = EntityState.Modified;
                _senatiContext.SaveChanges();
                return true; // Retorna verdadero si la operación es exitosa.
            }
            catch (Exception ex)
            {
                return false; // Retorna falso si ocurre una excepción.
            }
        }

        // Método HTTP POST para eliminar un técnico.
        [HttpPost]
        [Route("DeleteTecnico")]
        public bool DeleteProducto(Tecnico tecnico)
        {
            try
            {
                // Busca el técnico por su ID.
                var dbTecnico = _senatiContext.Tecnicos.Find(tecnico.Id);

                // Si no se encuentra el técnico, retorna falso.
                if (dbTecnico == null)
                {
                    return false;
                }

                // Elimina el técnico del contexto y guarda los cambios.
                _senatiContext.Tecnicos.Remove(dbTecnico);
                _senatiContext.SaveChanges();
                return true; // Retorna verdadero si la operación es exitosa.
            }
            catch (Exception ex)
            {
                return false; // Retorna falso si ocurre una excepción.
            }
        }
    }
}