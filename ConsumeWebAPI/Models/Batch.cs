namespace ConsumeWebAPI.Models;

public class Batch
{
    public int Id { get; set; }
    public string BatchName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CourseId { get; set; }
    
}
