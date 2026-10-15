using System;

namespace HireNova.Data_Model.DTOs
{
    public class RecruiterDTO
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int UserType { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? CompanyName { get; set; }

        public string? JobTitle { get; set; }

        public string? VerificationStatus { get; set; }

        public string? ApprovalStatus { get; set; }
    }
}
