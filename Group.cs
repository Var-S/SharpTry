namespace SectTask;

public class Group
{    
    public List<Task> Tasks;
    public int? GroupId { get; set; }

    public Group(int Id)
    {
        Tasks = new List<Task>();
        GroupId = Id;
    }
}
