using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EleicaoBrasilApi.Data;
using EleicaoBrasilApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EleicaoBrasilApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
       private readonly AppDbContext _context;
       
        public CandidatosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var candidatos = _context.Candidatos.ToList();
            return Ok(candidatos);
        }

            [HttpPost]
            
        public IActionResult Post(Candidato candidato)
        {            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = candidato.Id }, candidato);
        }
[HttpPut("{id}")]
        public IActionResult Put(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return BadRequest();
            }

        _context .Candidatos.Update(candidato);
        _context.SaveChanges();
        return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)   
        {
            var candidato = _context.Candidatos.Find(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            _context.SaveChanges();
            return NoContent();
        }
    }
}