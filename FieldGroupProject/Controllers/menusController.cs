using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FieldGroupProject.Models;

namespace FieldGroupProject.Controllers
{
    public class menusController : Controller
    {
        private Delivery_DBEntities db = new Delivery_DBEntities();


        // GET: menus
        [Authorize(Roles = "Restaurant,Customer")]
        public async Task<ActionResult> Index()
        {
            var menus = db.menus.Include(m => m.AspNetUser);
            return View(await menus.ToListAsync());
        }

        // GET: menus/Details/5
        [Authorize(Roles = "Restaurant, Customer")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = await db.menus.FindAsync(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: menus/Create
        [Authorize(Roles = "Restaurant")]

        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Restaurant")]

        public async Task<ActionResult> Create([Bind(Include = "menuID,size,starch,protein,price,userId")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.menus.Add(menu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", menu.userId);
            return View(menu);
        }

        // GET: menus/Edit/5
        [Authorize(Roles = "Restaurant")]

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = await db.menus.FindAsync(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", menu.userId);
            return View(menu);
        }

        // POST: menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "menuID,size,starch,protein,price,userId")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", menu.userId);
            return View(menu);
        }

        // GET: menus/Delete/5
        [Authorize(Roles = "Restaurant")]

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = await db.menus.FindAsync(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            menu menu = await db.menus.FindAsync(id);
            db.menus.Remove(menu);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
