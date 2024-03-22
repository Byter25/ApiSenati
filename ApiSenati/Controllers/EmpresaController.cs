using AppCosoleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSenati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private SenatiContext _senatiContext;

        public EmpresaController(SenatiContext senatiContext) { 
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Empresa> Get()
        {
            return _senatiContext.Empresas.ToList();
        }

        [HttpPost]
        [Route("AddEmpresa")]
        public bool AddAlumno([FromBody] Empresa empresa)
        {
            try
            {
                _senatiContext.Empresas.Add(empresa);
                _senatiContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateEmpresa")]
        public bool UpdateAlumno([FromBody] Empresa empresa)
        {
            try
            {
                _senatiContext.Entry(empresa).State = EntityState.Modified;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteEmpresa")]
        public bool DeleteProducto(Empresa empresa)
        {
            try
            {
                var dbEmpresa = _senatiContext.Empresas.Find(empresa.Id);

                if (dbEmpresa == null)
                {
                    return false;
                }

                _senatiContext.Empresas.Remove(dbEmpresa);
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
