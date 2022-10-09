using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResolutionAssignment.Data;
using ResolutionAssignment.Models;

namespace ResolutionAssignment.Controllers;

public class BogusController : Controller
{
  private readonly ApplicationDbContext _context;

  public BogusController(ApplicationDbContext context)
  {
    _context = context;
  }

  // GET: Resolution
  public async Task<IActionResult> Index()
  {
    var data = _context.Resolutions.Include(r => r.Owner);
    return View(await data.ToListAsync());
    // return View();
  }

  public async Task<IActionResult> Details(string id)
  {
    if (id == null || _context.Resolutions == null)
    {
      return NotFound();
    }

    var resolution = await _context.Resolutions
      .Include(r => r.Owner)
      .FirstOrDefaultAsync(m => m.ResolutionId == id);
    if (resolution == null)
    {
      return NotFound();
    }

    return View(resolution);
  }

  // GET: Resolution/Create
  public IActionResult Create()
  {
    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
    return View();
  }

  // POST: Resolution/Create
  // To protect from overposting attacks, enable the specific properties you want to bind to.
  // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create([Bind("ResolutionId,CreationDate,Abstract,Status,UserId")] Resolution resolution)
  {
    if (ModelState.IsValid)
    {
      _context.Add(resolution);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", resolution.UserId);
    return View(resolution);
  }

  // GET: Resolution/Edit/5
  public async Task<IActionResult> Edit(string id)
  {
    if (id == null || _context.Resolutions == null)
    {
      return NotFound();
    }

    var resolution = await _context.Resolutions.FindAsync(id);
    if (resolution == null)
    {
      return NotFound();
    }
    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", resolution.UserId);
    return View(resolution);
  }

  // POST: Resolution/Edit/5
  // To protect from overposting attacks, enable the specific properties you want to bind to.
  // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(string id, [Bind("ResolutionId,CreationDate,Abstract,Status,UserId")] Resolution resolution)
  {
    if (id != resolution.ResolutionId)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(resolution);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ResolutionExists(resolution.ResolutionId))
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
    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", resolution.UserId);
    return View(resolution);
  }

  // GET: Resolution/Delete/5
  public async Task<IActionResult> Delete(string id)
  {
    if (id == null || _context.Resolutions == null)
    {
      return NotFound();
    }

    var resolution = await _context.Resolutions
      .Include(r => r.Owner)
      .FirstOrDefaultAsync(m => m.ResolutionId == id);
    if (resolution == null)
    {
      return NotFound();
    }

    return View(resolution);
  }

  // POST: Resolution/Delete/5
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(string id)
  {
    if (_context.Resolutions == null)
    {
      return Problem("Entity set 'ApplicationDbContext.Resolutions'  is null.");
    }
    var resolution = await _context.Resolutions.FindAsync(id);
    if (resolution != null)
    {
      _context.Resolutions.Remove(resolution);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }

  private bool ResolutionExists(string id)
  {
    return (_context.Resolutions?.Any(e => e.ResolutionId == id)).GetValueOrDefault();
  }
}
