using AppCosoleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSenati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private SenatiContext _senatiContext;

        public ClienteController(SenatiContext senatiContext)
        {
            _senatiContext = senatiContext;
        }

        [HttpGet]
        [Route("Get")]
        public List<Cliente> Get()
        {
            return _senatiContext.Clientes.ToList();
        }

        [HttpPost]
        [Route("AddCliente")]
        public bool AddCurso([FromBody] Cliente cliente)
        {
            try
            {
                _senatiContext.Clientes.Add(cliente);
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("UpdateCliente")]
        public bool UpdateAlumno([FromBody] Cliente cliente)
        {
            try
            {
                _senatiContext.Entry(cliente).State = EntityState.Modified;
                _senatiContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("DeleteCliente")]
        public bool DeleteProducto(Cliente cliente)
        {
            try
            {
                var dbCliente = _senatiContext.Clientes.Find(cliente.Id);

                if (dbCliente== null)
                {
                    return false;
                }

                _senatiContext.Clientes.Remove(dbCliente);
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
