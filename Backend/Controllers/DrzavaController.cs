using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DrzavaController : ControllerBase
    {

        private readonly BackendContext _context;

        public DrzavaController(BackendContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Drzave);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{sifra:int}")]
        public IActionResult GetById(int sifra)
        {
            if (sifra <= 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { poruka = "Šifra mora biti pozitivan broj" });
            }
            try
            {
                var drzava = _context.Drzave.Find(sifra);
                if (drzava == null)
                {
                    return NotFound(new { poruka = $"Država s šifrom {sifra} ne postoji" });
                }
                return Ok(drzava);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }




        [HttpPost]
        public IActionResult Post(Drzava drzava)
        {
            try
            {
                _context.Drzave.Add(drzava);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, drzava);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public IActionResult Put(int sifra, Drzava drzava)
        {
            try
            {
                var drzavaBaza = _context.Drzave.Find(sifra);
                if (drzavaBaza == null)
                {
                    return NotFound(new { poruka = $"Država s šifrom {sifra} ne postoji" });
                }
                // rucni mapping - kasnije auto
                drzavaBaza.Naziv = drzava.Naziv;

                _context.Drzave.Update(drzava);
                _context.SaveChanges();
                return Ok(drzava);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int sifra)
        {
            if (sifra<=0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { poruka = "Šifra mora biti pozitivan broj" });
            }
            try
            {
                var drzava = _context.Drzave.Find(sifra);
                if (drzava == null)
                {
                    return NotFound(new { poruka = $"Država s šifrom {sifra} ne postoji" });
                }
                _context.Drzave.Remove(drzava);
                _context.SaveChanges();
                return NoContent ();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
