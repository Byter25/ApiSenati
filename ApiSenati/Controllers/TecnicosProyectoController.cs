using AppCosoleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSenati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosProyectoController : Controller
    {
        private SenatiContext _senatiContext;

        public TecnicosProyectoController(SenatiContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<TecnicosProyecto> Get()
        {
            return _senatiContext.TecnicosProyectos.ToList();
        }

        [HttpPost]
        [Route("AddTecnicosProyecto")]
        public bool AddAlumno([FromBody] TecnicosProyecto tecnicosProyecto)
        {
            try
            {
                _senatiContext.TecnicosProyectos.Add(tecnicosProyecto);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateTecnicosProyecto")]
        public bool UpdateAlumno([FromBody] TecnicosProyecto tecnicosProyecto)
        {
            try
            {
                _senatiContext.Entry(tecnicosProyecto).State = EntityState.Modified;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteTecnicosProyecto")]
        public bool DeleteProducto(TecnicosProyecto tecnicoProyecto)
        {
            try
            {
                var dbTecnicosProyectos = _senatiContext.TecnicosProyectos.Find(tecnicoProyecto.Id);

                if (dbTecnicosProyectos == null)
                {
                    return false;
                }

                _senatiContext.TecnicosProyectos.Remove(dbTecnicosProyectos);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}