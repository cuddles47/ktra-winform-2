using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using deonso9.Models;

namespace deonso9.Controllers
{
    public class MayGiatsController : Controller
    {
        private MayGiatDataContext db = new MayGiatDataContext();

        // GET: MayGiatsb (2 Min)
        public ActionResult hienthiMin()
        {
            var dongiamin = db.MayGiats.OrderBy(m => m.DonGia).Take(2).ToList();
           
            return View(dongiamin);
        }


       
        public ActionResult hienthiTheongaySX()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult hienthiTheongaySX(DateTime? ngaysx)
        {
            if (!ngaysx.HasValue)
            {
                ModelState.AddModelError("ngaySX", "Vui lòng chọn ngày sản xuất.");
                return View(new List<deonso9.Models.MayGiat>()); // Trả về danh sách rỗng
            }

            var startDate = ngaysx.Value.Date;
            var endDate = startDate.AddDays(1);

            var dbMaygiat = db.MayGiats
                .Where(m => m.ngaySX >= startDate && m.ngaySX < endDate)
                .ToList();

            return View(dbMaygiat);
        }


        // GET: MayGiats
        public ActionResult Index()
        {
            return View(db.MayGiats.ToList());
        }

        // GET: MayGiats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayGiat mayGiat = db.MayGiats.Find(id);
            if (mayGiat == null)
            {
                return HttpNotFound();
            }
            return View(mayGiat);
        }

        // GET: MayGiats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MayGiats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,HangSX,ngaySX,KhoiLuongGiat,DonGia,SoLuong")] MayGiat mayGiat)
        {
            if (ModelState.IsValid)
            {
                db.MayGiats.Add(mayGiat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mayGiat);
        }

        // GET: MayGiats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayGiat mayGiat = db.MayGiats.Find(id);
            if (mayGiat == null)
            {
                return HttpNotFound();
            }
            return View(mayGiat);
        }

        // POST: MayGiats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,HangSX,ngaySX,KhoiLuongGiat,DonGia,SoLuong")] MayGiat mayGiat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mayGiat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mayGiat);
        }

        // GET: MayGiats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayGiat mayGiat = db.MayGiats.Find(id);
            if (mayGiat == null)
            {
                return HttpNotFound();
            }
            return View(mayGiat);
        }

        // POST: MayGiats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MayGiat mayGiat = db.MayGiats.Find(id);
            db.MayGiats.Remove(mayGiat);
            db.SaveChanges();
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
