using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiBensas.Models;

namespace RestApiBensas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TankkausController : ControllerBase
    {
        private readonly TankkausDbContext _dbcontext;

        public TankkausController(TankkausDbContext context)
        {
            _dbcontext = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUpdate5LatestAsync()
        {
            try
            {
                var tankkaus = await _dbcontext.Tankkaus.OrderByDescending(t => t.TankkausId).Take(5).ToListAsync();
                return Ok(tankkaus);
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää: " + e.InnerException.Message);
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var tankkaus = _dbcontext.Tankkaus.OrderByDescending(t => t.TankkausId).ToList();
                return Ok(tankkaus);
            }
            catch (Exception e)
            {
                return BadRequest($"Tapahtui virhe. Lue lisää: {e.InnerException}");
            }
        }

        [HttpGet("yhteenveto/{ajoneuvoId}")]
        public IActionResult GetTankkausYhteenveto(int ajoneuvoId)
        {
            var yhteenveto = _dbcontext.Tankkaus
                .Where(t => t.AjoneuvoId == ajoneuvoId)
                .GroupBy(t => t.AjoneuvoId)
                .Select(k => new
                {
                    AjoneuvoId = k.Key,
                    Tankkauskerrat = k.Count(),
                    Kokonaiskulutus = k.Sum(t => t.Litraa),
                    KäytettyEuromäärä = k.Sum(t => t.Euroa)
                })
                .FirstOrDefault();

            if (yhteenveto == null)
            {
                return NotFound();
            }

            return Ok(yhteenveto);
        }



        [HttpPost]
        public async Task<ActionResult> AddNew(Tankkau tank)
        {
            try
            {
                _dbcontext.Tankkaus.Add(tank);
                await _dbcontext.SaveChangesAsync();
                return await GetUpdate5LatestAsync();
            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää: " + e.InnerException);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] Tankkau tank)
        {
            try
            {
                var tankkaus = _dbcontext.Tankkaus.Find(id);

                if (tankkaus != null)
                {
                    tankkaus.Ajokilometrit = tank.Ajokilometrit;
                    tankkaus.Litraa = tank.Litraa;
                    tankkaus.Euroa = tank.Euroa;

                    _dbcontext.SaveChanges();

                    return Ok($"Tankkausta muokattu");
                }
                else
                {
                    return NotFound($"Tankkausta ei löydy");
                }

            }
            catch (Exception e)
            {
                return BadRequest("Tapahtui virhe. Lue lisää: " + e.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var tankkaus = _dbcontext.Tankkaus.Find(id);

                if (tankkaus != null)
                {
                    _dbcontext.Tankkaus.Remove(tankkaus);
                    _dbcontext.SaveChanges();
                    return Ok($"Tankkaus poistettiin!");
                }
                else
                {
                    return NotFound($"Tankkausta ei löytynyt");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.InnerException);
            }
        }
    }
}
