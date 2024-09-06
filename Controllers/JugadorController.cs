using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TransferMarket.Data;
using TransferMarket.Models;

namespace TransferMarket.Controllers
{
    [Route("[controller]")]
    public class JugadorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JugadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Jugador> lista = await _context.Jugadores.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            var jugador = new Jugador(); // Crear una instancia de Jugador
            return View(jugador); // Pasar la instancia a la vista
        }


        [HttpPost]
        public async Task<IActionResult> Nuevo(Jugador jugador)
        {
            await _context.Jugadores.AddAsync(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Jugador jugador = await _context.Jugadores.FirstAsync(j => j.Id == id);
            return View(jugador);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Jugador jugador)
        {
            _context.Jugadores.Update(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Jugador jugador = await _context.Jugadores.FirstAsync(j => j.Id == id);
            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}