using System;

namespace HireNova.Data_Model.DTOs
{
    public class CandidateEducationDTO
    {
        public int EducationId { get; set; }

        public int UserId { get; set; }

        public string Qualification { get; set; } = string.Empty;

        public string InstitutionName { get; set; } = string.Empty;

        public string? Specialization { get; set; }

        public int? PassingYear { get; set; }

        public decimal? Percentage { get; set; }

        public decimal? CGPA { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
