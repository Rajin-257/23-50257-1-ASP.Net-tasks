using Blood_Donation_Management.EF;
using Blood_Donation_Management.EF.Tables;
using Blood_Donation_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blood_Donation_Management.Controllers
{
    public class ReportController : Controller
    {
        BloodBankContext db = new BloodBankContext();

        public IActionResult FilterByBloodGroup(string bloodGroup)
        {
            ViewBag.BloodGroups = (from d in db.Donors
                                   where d.BloodGroup != null
                                   select d.BloodGroup).Distinct().ToList();
            ViewBag.Selected = bloodGroup;

            var data = string.IsNullOrEmpty(bloodGroup)
                ? new List<Donor>()
                : (from d in db.Donors
                   where d.BloodGroup == bloodGroup
                   select d).ToList();
            return View(data);
        }

        public IActionResult SortedByLastDonation()
        {
            var data = (from d in db.Donors
                        orderby d.LastDonationDate descending
                        select d).ToList();
            return View(data);
        }

        public IActionResult DonorDonationCount()
        {
            var data = (from d in db.Donors
                        select new DonorDonationCountModel
                        {
                            DonorId = d.DonorId,
                            FullName = d.FullName,
                            BloodGroup = d.BloodGroup,
                            TotalDonations = d.Donations.Count()
                        }).ToList();
            return View(data);
        }

        public IActionResult TotalVolume()
        {
            var total = (from d in db.Donations
                         select d.VolumeMl).Sum() ?? 0;
            ViewBag.TotalVolume = total;
            return View();
        }
    }
}
