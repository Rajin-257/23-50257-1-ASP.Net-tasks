using Blood_Donation_Management.EF;
using Blood_Donation_Management.EF.Tables;
using Blood_Donation_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_Management.Controllers
{
    public class DonorController : Controller
    {
        BloodBankContext db = new BloodBankContext();

        public IActionResult Index()
        {
            ViewBag.Donors = db.Donors.ToList();
            return View(new DonorModel());
        }

        [HttpPost]
        public IActionResult Index(DonorModel Donor)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Donors = db.Donors.ToList();
                return View(Donor);
            }

            db.Donors.Add(new Donor
            {
                FullName = Donor.FullName,
                BloodGroup = Donor.BloodGroup,
                ContactNo = Donor.ContactNo,
                City = Donor.city,
                LastDonationDate = Donor.LastDonationDate
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var donor = db.Donors.Find(id);
            if (donor == null) return RedirectToAction("Index");

            return View(new DonorModel
            {
                DonorId = donor.DonorId,
                FullName = donor.FullName,
                BloodGroup = donor.BloodGroup,
                ContactNo = donor.ContactNo,
                city = donor.City,
                LastDonationDate = donor.LastDonationDate
            });
        }

        [HttpPost]
        public IActionResult Edit(DonorModel Donor)
        {
            if (!ModelState.IsValid)
            {
                return View(Donor);
            }

            var existing = db.Donors.Find(Donor.DonorId);
            if (existing == null) return RedirectToAction("Index");

            existing.FullName = Donor.FullName;
            existing.BloodGroup = Donor.BloodGroup;
            existing.ContactNo = Donor.ContactNo;
            existing.City = Donor.city;
            existing.LastDonationDate = Donor.LastDonationDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var donor = db.Donors.Find(id);
            if (donor != null)
            {
                db.Donors.Remove(donor);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
