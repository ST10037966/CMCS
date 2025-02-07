namespace ContactMonthlyClaimSystem.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        // FIX: Change Claim to MonthlyClaim
        public ICollection<MonthlyClaim> MonthlyClaims { get; set; }
    }
}