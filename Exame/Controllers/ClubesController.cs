using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exame.Data;
using Exame.Models;

namespace Exame.Controllers
{
    public class ClubesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clubes
        public async Task<IActionResult> Lista()
        {
            return View(await _context.Clubes.ToListAsync());
        }

        // GET: Clubes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clubes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sigla,Foto")] Clube clube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clube);
        }

        private bool ClubeExists(int id)
        {
            return _context.Clubes.Any(e => e.Id == id);
        }
    }
}
