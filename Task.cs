namespace SectTask;

public class SubTask
{
    public bool SubStatus { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    
    public SubTask(bool complete, string? name, string? description)
    {
        SubStatus = complete;
        Name = name;
        Description = description;
    }
    
}

public class Task
{
    public SubTask Sub;
    public int TaskId { get; set; }
    
    public bool TaskStatus { get; set; }
    public DateTime DeadLine { get; set; } // 01.01.0001 0:00:00

    public Task(int id, SubTask sub, DateTime deadline, bool status)
    {
        TaskId = id;
        Sub = sub;
        DeadLine = deadline;
        TaskStatus = status;
    }

    public Task() { }
}

public class Group
{
    public Task? Tasks;
    public int? GroupId { get; set; }
}