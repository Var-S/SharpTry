namespace SectTask;

public class SubTask
{
    public bool Status { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int SubTaskId { get; set; }

    public SubTask(bool complete, int id, string? name, string? description)
    {
        Status = complete;
        Name = name;
        Description = description;
        SubTaskId = id;
    }

    public void ChangeStatus() => Status = !Status;
}