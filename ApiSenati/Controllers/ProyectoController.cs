using AppCosoleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSenati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : Controller
    {
        private SenatiContext _senatiContext;

        public ProyectoController(SenatiContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Proyecto> Get()
        {
            return _senatiContext.Proyectos.ToList();
        }

        [HttpPost]
        [Route("AddProyecto")]
        public bool AddAlumno([FromBody] Proyecto proyecto)
        {
            try
            {
                _senatiContext.Proyectos.Add(proyecto);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateProyecto")]
        public bool UpdateAlumno([FromBody] Proyecto proyecto)
        {
            try
            {
                _senatiContext.Entry(proyecto).State = EntityState.Modified;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteProyecto")]
        public bool DeleteProducto(Proyecto proyecto)
        {
            try
            {
                var dbProyecto = _senatiContext.Proyectos.Find(proyecto.Id);

                if (dbProyecto == null)
                {
                    return false;
                }

                _senatiContext.Proyectos.Remove(dbProyecto);
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
