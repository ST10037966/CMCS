namespace ContactMonthlyClaimSystem.Models
{
    public class Document
    {
        public int DocumentId { get; set; } // Primary Key
        public string FileName { get; set; }
        public string FilePath { get; set; }

        // Foreign key to MonthlyClaim
        public int MonthlyClaimId { get; set; }
        public MonthlyClaim MonthlyClaim { get; set; } // Navigation property
    }
}

