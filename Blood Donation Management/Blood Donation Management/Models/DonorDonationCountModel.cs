namespace Blood_Donation_Management.Models
{
    public class DonorDonationCountModel
    {
        public int DonorId { get; set; }
        public string FullName { get; set; }
        public string BloodGroup { get; set; }
        public int TotalDonations { get; set; }
    }
}
