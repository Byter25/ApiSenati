using AppCosoleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSenati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private SenatiContext _senatiContext;

        public CategoriaController(SenatiContext senatiContext) { 
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Categoria> Get()
        {
            return _senatiContext.Categorias.ToList();
        }

        [HttpPost]
        [Route("AddCategoria")]
        public bool AddAlumno([FromBody] Categoria categoria)
        {
            try
            {
                _senatiContext.Categorias.Add(categoria);
                _senatiContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateCategoria")]
        public bool UpdateAlumno([FromBody] Categoria categoria)
        {
            try
            {
                _senatiContext.Entry(categoria).State = EntityState.Modified;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteCategoria")]
        public bool DeleteProducto(Categoria categoria)
        {
            try
            {
                var dbCategoria = _senatiContext.Categorias.Find(categoria.Id);

                if (dbCategoria == null)
                {
                    return false;
                }

                _senatiContext.Categorias.Remove(dbCategoria);
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
