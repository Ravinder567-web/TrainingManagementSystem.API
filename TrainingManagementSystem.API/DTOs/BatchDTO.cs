using TrainingManagementSystem.API.Models;

namespace TrainingManagementSystem.API.DTOs
{
    public class BatchDTO
    {
        public int Id { get; set; }
        public string BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
    }

}
