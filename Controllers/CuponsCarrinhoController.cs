using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevSteamAPI.Data;
using DevSteamAPI.Models;

namespace DevSteamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponsCarrinhoController : ControllerBase
    {
        private readonly APIContext _context;

        public CuponsCarrinhoController(APIContext context)
        {
            _context = context;
        }

        // GET: api/CuponsCarrinho
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CupomCarrinho>>> GetCuponsCarrinho()
        {
            return await _context.CuponsCarrinho.ToListAsync();
        }

        // GET: api/CuponsCarrinho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CupomCarrinho>> GetCupomCarrinho(Guid id)
        {
            var cupomCarrinho = await _context.CuponsCarrinho.FindAsync(id);

            if (cupomCarrinho == null)
            {
                return NotFound();
            }

            return cupomCarrinho;
        }

        // PUT: api/CuponsCarrinho/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCupomCarrinho(Guid id, CupomCarrinho cupomCarrinho)
        {
            if (id != cupomCarrinho.CupomCarrinhoId)
            {
                return BadRequest();
            }

            _context.Entry(cupomCarrinho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CupomCarrinhoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CuponsCarrinho
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CupomCarrinho>> PostCupomCarrinho(CupomCarrinho cupomCarrinho)
        {
            _context.CuponsCarrinho.Add(cupomCarrinho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCupomCarrinho", new { id = cupomCarrinho.CupomCarrinhoId }, cupomCarrinho);
        }

        // DELETE: api/CuponsCarrinho/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupomCarrinho(Guid id)
        {
            var cupomCarrinho = await _context.CuponsCarrinho.FindAsync(id);
            if (cupomCarrinho == null)
            {
                return NotFound();
            }

            _context.CuponsCarrinho.Remove(cupomCarrinho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CupomCarrinhoExists(Guid id)
        {
            return _context.CuponsCarrinho.Any(e => e.CupomCarrinhoId == id);
        }

        // Método POST para aplicar um cupom ao carrinho
        [HttpPost]
        [Route("AplicarCupom/{id}")]
        public async Task<IActionResult> AplicarCupom(Guid carrinhoId, Guid cupomId)
        {
            //Verificar se o carrinho existe
            var carrinho = await _context.Carrinhos.FindAsync(carrinhoId);
            if (carrinho == null)
            {
                return NotFound("Carrinho não encontrado");
            }

            //Verificar se o cupom existe
            var cupom = await _context.Cupons.FindAsync(cupomId);
            if (cupom == null)
            {
                return NotFound("Cupom não encontrado");
            }

            //Verifica se o cupom é válido e está ativo
            if (cupom.DataValidade < DateTime.Now || cupom.Ativo == false)
            {
                return BadRequest("Cupom inválido ou inativo.");
            }

            //Verificar se o carrinho foi finalizado
            if (carrinho.Finalizado)
            {
                return BadRequest("Carrinho já finalizado");
            }

            _context.Entry(cupom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();


        }

    }
}
