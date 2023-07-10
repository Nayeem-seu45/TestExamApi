using TestExamPortal.Enums;

namespace TestExamPortal.Models
{
    public class PatientInfoViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DeseaseId { get; set; }
        public string? DeseaseName { get; set; }
        public Epilepsy EpilepsyId { get; set; }
        public List<NCDViewModel>? NCDs { get; set; }
        public List<AllergieViewModel>? Allergies { get; set; }
    }
}
