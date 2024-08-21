using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiBensas.Models;

namespace RestApiBensas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjoneuvotController : ControllerBase
    {
        private readonly TankkausDbContext _dbcontext;

        public AjoneuvotController(TankkausDbContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public ActionResult GetAllAjoneuvot()
        {
            try
            {
                var autot = _dbcontext.Ajoneuvots.ToList();
                return Ok(autot);
            }
            catch (Exception e)
            {
                return BadRequest($"Tapahtui virhe. Lue lisää: {e.InnerException}");
            }
        }

        [HttpPost]
        public ActionResult AddNewAjoneuvot(Ajoneuvot car)
        {
            try
            {
                _dbcontext.Ajoneuvots.Add(car);
                _dbcontext.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää: " + e.InnerException);
            }
        }
    }
}
