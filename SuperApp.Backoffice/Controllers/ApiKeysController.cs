using SuperApp.Backoffice.Models;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SuperApp.Backoffice.Controllers
{
    public class ApiKeysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApiKeys
        public async Task<ActionResult> Index()
        {
            return View(await db.ApiKeys.ToListAsync());
        }

        // GET: ApiKeys/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApiKey apiKey = await db.ApiKeys.FindAsync(id);
            if (apiKey == null)
            {
                return HttpNotFound();
            }
            return View(apiKey);
        }

        // GET: ApiKeys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApiKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] ApiKey apiKey)
        {
            if (ModelState.IsValid)
            {
                apiKey.Key = Guid.NewGuid();

                db.ApiKeys.Add(apiKey);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(apiKey);
        }

        // GET: ApiKeys/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApiKey apiKey = await db.ApiKeys.FindAsync(id);
            if (apiKey == null)
            {
                return HttpNotFound();
            }
            return View(apiKey);
        }

        // POST: ApiKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Key")] ApiKey apiKey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apiKey).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apiKey);
        }

        // GET: ApiKeys/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApiKey apiKey = await db.ApiKeys.FindAsync(id);
            if (apiKey == null)
            {
                return HttpNotFound();
            }
            return View(apiKey);
        }

        // POST: ApiKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApiKey apiKey = await db.ApiKeys.FindAsync(id);
            db.ApiKeys.Remove(apiKey);
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
