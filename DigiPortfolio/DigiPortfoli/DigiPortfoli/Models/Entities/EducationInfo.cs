namespace DigiPortfoli.Models.Entities
{
    public class EducationInfo
    {
        public int Id { get; set; }
        public string? TITLE { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Department { get; set; }
        public string? Institution { get; set; }
        public string? Description { get; set; }
        public decimal? Grade { get; set; } 
    }
}
