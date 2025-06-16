namespace TrainingManagementSystem.API.Models
{
    public class Enrolment
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Status { get; set; } 
    }
}
