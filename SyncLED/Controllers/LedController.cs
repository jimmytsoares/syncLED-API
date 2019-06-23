using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyncLED.Models;

namespace SyncLED.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedController : ControllerBase
    {
        private readonly SyncLED_DBContext _context;

        public LedController(SyncLED_DBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetInfo(int id)
        {
            try
            {
                var ret = _context.Luminarias.First(f => f.Id == id);
                return Ok(ret);
            }
            catch
            {
                return BadRequest("Id inválido");
            }
        }

        [HttpPost("novo")]
        public IActionResult NewLum([FromBody]Luminarias lum)
        {
            try
            {
                _context.Luminarias.Add(new Luminarias() {
                    Id = lum.Id,
                    UsuarioId = lum.UsuarioId,
                    Nome = lum.Nome,
                    SensorPresenca = lum.SensorPresenca,
                    ModoAuto = lum.ModoAuto
                });
                _context.SaveChanges();
                return Ok("Adicionado com sucesso!");
            }
            catch
            {
                return BadRequest("Erro ao adicionar luminária");
            }
        }
    }
}