using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_Management.Models
{
    public class DonorModel
    {
        public int DonorId { get; set; }

        [Required(ErrorMessage = "Full Name is required"), StringLength(50)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Blood Group is required"), StringLength(3)]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Contact No is required"), StringLength(13)]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "City is required"), StringLength(50)]
        public string city { get; set; }
        [Required(ErrorMessage = "Last Donation Date is required")]
        public DateOnly LastDonationDate { get; set; }
    }
}
