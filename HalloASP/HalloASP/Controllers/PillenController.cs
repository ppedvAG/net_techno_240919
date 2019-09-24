using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HalloASP.Models;

namespace HalloASP.Controllers
{
    public class PillenController : Controller
    {
        private readonly HalloASPContext _context;

        public PillenController(HalloASPContext context)
        {
            _context = context;
        }

        // GET: Pillen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pille.ToListAsync());
        }

        // GET: Pillen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pille = await _context.Pille
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pille == null)
            {
                return NotFound();
            }

            return View(pille);
        }

        // GET: Pillen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pillen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gewicht")] Pille pille)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pille);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pille);
        }

        // GET: Pillen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pille = await _context.Pille.FindAsync(id);
            if (pille == null)
            {
                return NotFound();
            }
            return View(pille);
        }

        // POST: Pillen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gewicht")] Pille pille)
        {
            if (id != pille.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pille);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilleExists(pille.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pille);
        }

        // GET: Pillen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pille = await _context.Pille
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pille == null)
            {
                return NotFound();
            }

            return View(pille);
        }

        // POST: Pillen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pille = await _context.Pille.FindAsync(id);
            _context.Pille.Remove(pille);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilleExists(int id)
        {
            return _context.Pille.Any(e => e.Id == id);
        }
    }
}
