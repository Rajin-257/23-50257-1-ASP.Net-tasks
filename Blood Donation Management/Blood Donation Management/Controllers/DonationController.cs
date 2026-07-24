using Blood_Donation_Management.EF;
using Blood_Donation_Management.EF.Tables;
using Blood_Donation_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_Management.Controllers
{
    public class DonationController : Controller
    {
        BloodBankContext db = new BloodBankContext();

        public IActionResult Index()
        {
            ViewBag.Donations = db.Donations.Include(d => d.Donor).ToList();
            ViewBag.Donors = db.Donors.ToList();
            return View(new DonationModel());
        }

        [HttpPost]
        public IActionResult Index(DonationModel Donation)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Donations = db.Donations.Include(d => d.Donor).ToList();
                ViewBag.Donors = db.Donors.ToList();
                return View(Donation);
            }

            db.Donations.Add(new Donation
            {
                DonorId = Donation.DonorId,
                DonationDate = Donation.DonationDate,
                VolumeMl = Donation.VolumeMl,
                CampName = Donation.CampName
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var donation = db.Donations.Find(id);
            if (donation == null) return RedirectToAction("Index");

            ViewBag.Donors = db.Donors.ToList();
            return View(new DonationModel
            {
                DonationId = donation.DonationId,
                DonorId = donation.DonorId,
                DonationDate = donation.DonationDate,
                VolumeMl = (float)(donation.VolumeMl),
                CampName = donation.CampName
            });
        }

        [HttpPost]
        public IActionResult Edit(DonationModel Donation)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Donors = db.Donors.ToList();
                return View(Donation);
            }

            var existing = db.Donations.Find(Donation.DonationId);
            if (existing == null) return RedirectToAction("Index");

            existing.DonorId = Donation.DonorId;
            existing.DonationDate = Donation.DonationDate;
            existing.VolumeMl = Donation.VolumeMl;
            existing.CampName = Donation.CampName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var donation = db.Donations.Find(id);
            if (donation != null)
            {
                db.Donations.Remove(donation);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
