namespace SectTask;
using System.Text.Json;

public class Methods
{
    private List<Task?> _taskData = new List<Task?>();
    private List<Group?> _groupData = new List<Group?>();
    private List<SubTask?> _subData = new List<SubTask?>();
    
    public void AddTask(int id, SubTask sub, DateTime deadline, bool complete)
    {
        _taskData.Add(new Task() {TaskId = id, Sub = sub, DeadLine = deadline, TaskStatus = complete} );
        Console.WriteLine("Task Created!");
    }

    public void AddSubTask(int Taskid, SubTask sub)
    {
        foreach (var t in _taskData.Where(t => t!.TaskId == Taskid))
        {
            t!.Sub = sub;
        }
        
        Console.WriteLine("SubTask Created!");
    }

    public void ChangeSubStatus(int id)
    {
        foreach (var t in _subData.Where(t => t!.SubStatus == false))
        {
            t!.SubStatus = true;
        }
        Console.WriteLine("Status Changed!");
    }
    public void ShowTasks()
    {
        foreach (var t in _taskData)
        {
            Console.WriteLine(t!.TaskId);
            Console.WriteLine(t!.TaskStatus);
            var json = JsonSerializer.Serialize(t?.Sub);
            var json1 = JsonSerializer.Serialize(t?.DeadLine);
            Console.WriteLine(json);
            Console.WriteLine(json1);
        }
    }
    
    public void ShowTasks(int id)
    {
        foreach (var t in _taskData)
        {
            if (t!.TaskId == id){
                Console.WriteLine(t!.TaskId);
                Console.WriteLine(t!.TaskStatus);
                var json = JsonSerializer.Serialize(t?.Sub);
                var json1 = JsonSerializer.Serialize(t?.DeadLine);
                Console.WriteLine(json);
                Console.WriteLine(json1);
            }
            else
            {
                Console.WriteLine("Wrong Id");
            }
        }
    }
    
    public void DeleteTask(int id)
    {
        for (var i = 0; i < _taskData.Count; ++i)
        {
            if (_taskData[i]!.TaskId == id)
            {
                _taskData.Remove(_taskData[i]);
            }
        }
    }
    
    public void ChangeStatus(int id)
    {
        foreach (var t in _taskData.Where(t => t!.TaskStatus == false))
        {
            t!.TaskStatus = true;
        }
        Console.WriteLine("Status Changed!");
    }
    
    public void toFile(string? ph)
    {
        var str = new StreamWriter(ph!);
        foreach (var t in _taskData)
        {
            str.WriteLine(t!.TaskId);
            str.WriteLine(t!.TaskStatus);
            var json = JsonSerializer.Serialize(t?.Sub);
            var json1 = JsonSerializer.Serialize(t?.DeadLine);
            str.WriteLine(json);
            str.WriteLine(json1);
        }
        str.Close();
    }

    public void fromFile(string? ph)
    {
        if (File.Exists(ph))
        {
            using StreamReader reader = new StreamReader(ph);
            _taskData.Clear();
            for (int i = 0; i < System.IO.File.ReadAllLines(ph).Length; ++i)
            {
                string? json = reader.ReadLine();
                if (json != null) _taskData.Add(JsonSerializer.Deserialize<Task>(json));
            }
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }
    
    public void DayCheck()
    {
        foreach (var json in from t in _taskData where t!.DeadLine.Day == DateTime.Now.Day select JsonSerializer.Serialize(t))
        {
            Console.WriteLine(json);
        }
    }

    public void CreateGroup(int id)
    {
        _groupData.Add(new Group(){GroupId = id,Tasks = null});
    }

    public void AddToGroup(int Taskid, int Groupid)
    {
        foreach (var t in _taskData.Where(t => t!.TaskId == Taskid))
        {
            foreach (var t1 in _groupData.Where(t1 => t1!.GroupId == Groupid))
            {
                t1!.Tasks = t;
            }
        }
    }

    public void ShowGroup()
    {
        foreach (var t in _groupData)
        {
            var json = JsonSerializer.Serialize(t!.GroupId);
            var json1 = JsonSerializer.Serialize(t!.Tasks);
            if (json == "null")
            {
                Console.Write("");
            }
            else
            {
                Console.WriteLine(json);    
            }
            if (json1 == "null")
            {
                Console.Write("");
            }
            else
            {
                Console.WriteLine(json1);    
            }
        }
    }

    public void DeleteGroup(int id)
    {
        foreach (var t in _groupData)
        {
            if (t!.GroupId == id)
            {
                t.Tasks = null;
                t.GroupId = null;
            }
        }
    }

    public void DeleteFromGroup(int Groupid, int Taskid)
    {
        for (int i = 0; i < _groupData.Count; ++i)
        {
            if (_groupData[i]!.GroupId == Groupid)
            {
                for (int j = 0; j < _taskData.Count; ++j)
                {
                    if (_taskData[j]!.TaskId == Taskid)
                    {
                        _groupData[i]!.Tasks = null;
                    }
                }
            }
        } 
    }
    
}