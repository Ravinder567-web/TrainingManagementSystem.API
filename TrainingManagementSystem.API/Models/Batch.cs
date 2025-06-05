namespace TrainingManagementSystem.API.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public string BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Enrolment> Enrolments { get; set; }
    }
}
