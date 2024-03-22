using AppCosoleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSenati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConocimientoController : Controller
    {
        private SenatiContext _senatiContext;

        public ConocimientoController(SenatiContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Conocimiento> Get()
        {
            return _senatiContext.Conocimientos.ToList();
        }

        [HttpPost]
        [Route("AddConocimiento")]
        public bool AddCurso([FromBody] Conocimiento conocimiento)
        {
            try
            {
                _senatiContext.Conocimientos.Add(conocimiento);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateConocimiento")]
        public bool UpdateAlumno([FromBody] Conocimiento conocimiento)
        {
            try
            {
                _senatiContext.Entry(conocimiento).State = EntityState.Modified;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteConocimiento")]
        public bool DeleteProducto(Conocimiento conocimiento)
        {
            try
            {
                var dbConocimiento = _senatiContext.Conocimientos.Find(conocimiento.Id);

                if (dbConocimiento == null)
                {
                    return false;
                }

                _senatiContext.Conocimientos.Remove(dbConocimiento);
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
