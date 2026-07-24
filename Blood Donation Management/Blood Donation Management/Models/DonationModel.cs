using System.ComponentModel.DataAnnotations;

namespace Blood_Donation_Management.Models
{
    public class DonationModel
    {
        public int DonationId { get; set; }

        [Required(ErrorMessage = "Donor is required")]
        public int DonorId { get; set; }
        [Required(ErrorMessage = "Donation Date is required")]
        public DateOnly DonationDate { get; set; }
        [Required(ErrorMessage = "Volume is required"), Range(100, 1500)]
        public float VolumeMl { get; set; }
        [Required(ErrorMessage = "Camp Name is required"), StringLength(50)]
        public string CampName { get; set; }
    }
}
