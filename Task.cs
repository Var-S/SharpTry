namespace SectTask;
public class Task
{
    public List<SubTask> SubTasks;
    public int TaskId { get; set; }
    public bool TaskStatus { get; set; }
    public DateTime DeadLine { get; set; } // 01.01.0001 0:00:00

    public Task(int id, DateTime deadline, bool status)
    {
        TaskId = id;
        SubTasks = new List<SubTask>();
        DeadLine = deadline;
        TaskStatus = status;
    }
}
