using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoTProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GoTProject.Areas.Identity.Data;

namespace GoTProject.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly GoTProjectContext _context;
        private readonly UserManager<GoTProjectUser> _userManager;
        public ReservationsController(GoTProjectContext context, UserManager<GoTProjectUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reservations
        [Authorize(Roles = "Admin, InventoryManager, Employee, Customer")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        [Authorize(Roles = "Admin, InventoryManager, Employee, Customer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        [Authorize(Roles = "Admin, InventoryManager, Employee, Customer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, InventoryManager, Employee, Customer")]
        public async Task<IActionResult> Create([Bind("ID,DateOfReservation,Cancelled,PartyName")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.Reservee = await _userManager.FindByNameAsync(User.Identity.Name);

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Reservations/Edit/5
        [Authorize(Roles = "Admin, InventoryManager, Employee, Customer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, InventoryManager, Employee, Customer")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateOfReservation,Cancelled,PartyName")] Reservation reservation)
        {
            if (id != reservation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Reservations cannot be created already cancelled
                    reservation.Cancelled = false;

                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ID))
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
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        [Authorize(Roles = "Admin, InventoryManager, Employee")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, InventoryManager, Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ID == id);
        }
    }
}
