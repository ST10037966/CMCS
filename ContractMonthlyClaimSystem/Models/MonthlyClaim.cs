namespace ContactMonthlyClaimSystem.Models
{
    public class MonthlyClaim
    {
        public int MonthlyClaimId { get; set; } // Primary Key

        public string Description { get; set; } // NEW FIELD: Description of Work Done
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }

        public double TotalAmount => HoursWorked * HourlyRate; // Auto-calculated

        public string Status { get; set; } // Pending, Approved, Rejected
        public DateTime SubmissionDate { get; set; }

        // Foreign Key for Lecturer
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        // Relationship with Documents
        public ICollection<Document> Documents { get; set; }
    }
}



