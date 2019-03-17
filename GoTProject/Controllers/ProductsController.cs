using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoTProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace GoTProject.Controllers
{
    [Authorize(Roles = "Admin, InventoryManager, Employee")]
    public class ProductsController : Controller
    {
        private readonly GoTProjectContext _context;

        public ProductsController(GoTProjectContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var goTProjectContext = _context.Inventory.Include(p => p._Supplier);
            return View(await goTProjectContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Inventory
                .Include(p => p._Supplier)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin, InventoryManager")]
        public IActionResult Create()
        {
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, InventoryManager")]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,SupplierID,UnitPrice,AmountInLBS,ArrivalTime,ExpirationDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID", product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin, InventoryManager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Inventory.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID", product.SupplierID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, InventoryManager")]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,SupplierID,UnitPrice,AmountInLBS,ArrivalTime,ExpirationDate")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID", product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin, InventoryManager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Inventory
                .Include(p => p._Supplier)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, InventoryManager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Inventory.Any(e => e.ProductID == id);
        }
    }
}
