using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Collection.Models;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Collection.Controllers
{
    public class CdsController : Controller
    {

        private readonly CdContext _context;

        public CdsController(CdContext context)
        {
            _context = context;
        }
        public static List<SelectListItem> ArtistDropDown()
        {
            List<SelectListItem> artists = new List<SelectListItem>();
            artists.Add(new SelectListItem() { Text = "Unspecified", Value = "-1" });
            SqliteConnection conn = new SqliteConnection(@"Data Source = CdDb.db");
            conn.Open();
            SqliteCommand cmd = new SqliteCommand("SELECT * FROM Artists", conn);
            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    artists.Add(new SelectListItem() { Text = (string)reader["Name"], Value = (string)reader["Id"].ToString() });
                }
            }
            
            return artists;
        }
        



        // GET: Cds
        public async Task<IActionResult> Index(string searchStr)
        {
            var cd = from Cds in _context.Cds select Cds;

            

            if (!String.IsNullOrEmpty(searchStr))
            {
                cd = cd.Where(c => c.Name.ToLower().Contains(searchStr.ToLower()));
            }
            


            return View(await cd.ToListAsync());
        }

        // GET: Cds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // GET: Cds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Artist_Id,Year")] Cd cd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cd);
        }

        // GET: Cds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cds.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }
            return View(cd);
        }

        // POST: Cds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Artist_Id,Year")] Cd cd)
        {
            if (id != cd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CdExists(cd.Id))
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
            return View(cd);
        }

        // GET: Cds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cd = await _context.Cds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // POST: Cds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cd = await _context.Cds.FindAsync(id);
            _context.Cds.Remove(cd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CdExists(int id)
        {
            return _context.Cds.Any(e => e.Id == id);
        }
    }
}
