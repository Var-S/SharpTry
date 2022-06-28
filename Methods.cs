using System.Data;
using System.Numerics;

namespace SectTask;

using System.Text.Json;

public class TaskManager
{
    private readonly List<Task> _taskData;
    private readonly List<Group> _groupData;

    public TaskManager()
    {
        _groupData = new List<Group>();
        _taskData = new List<Task>();
    }

    public void AddTask(int id, DateTime deadline, bool complete)
    {
        _taskData.Add(new Task(id, deadline, complete));
        Console.WriteLine("Task Created!");
    }

    public void AddSubTask(int taskId, SubTask subTask)
    {
        _taskData
            .FirstOrDefault(task => task.TaskId == taskId)
            ?.SubTasks
            .Add(subTask);
        Console.WriteLine("SubTask Created!");
    }

    public void ChangeSubtaskStatus(int taskId, int subTaskId)
    {
        _taskData
            .FirstOrDefault(task => task.TaskId == taskId)?
            .SubTasks
            .FirstOrDefault(subtask => subtask.SubTaskId == subTaskId)?
            .ChangeStatus();
        Console.WriteLine("Status Changed!");
    }

    public void ShowTasks()
    {
        foreach (var task in _taskData)
        {
            Console.WriteLine(task!.TaskId);
            Console.WriteLine(task!.TaskStatus);
            foreach (var task1 in task.SubTasks)
            {
                var json = JsonSerializer.Serialize(task1);
                Console.WriteLine(json);
            }

            var json1 = JsonSerializer.Serialize(task.DeadLine);
            Console.WriteLine(json1);
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

    public void ChangeTaskStatus(int id, bool status)
    {
        foreach (var t in _taskData)
        {
            t!.TaskStatus = status;
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
            var json = JsonSerializer.Serialize(t?.SubTasks);
            var json1 = JsonSerializer.Serialize(t?.DeadLine);
            str.WriteLine(json);
            str.WriteLine(json1);
        }

        str.Close();
    }

    public void fromFile(string? ph)
    {
        if (!File.Exists(ph))
        {
            throw new Exception("File not found");
        }

        using var reader = new StreamReader(ph);
        _taskData.Clear();
        for (var i = 0; i < System.IO.File.ReadAllLines(ph).Length; ++i)
        {
            var json = reader.ReadLine();
            if (json != null) _taskData.Add(JsonSerializer.Deserialize<Task>(json)!);
        }
    }

    public void PrintTodaysDeadline()
    {
        foreach (var task in _taskData)
        {
            if (task.DeadLine.Day == DateTime.Now.Day)
            {
                var json = JsonSerializer.Serialize(task);
                Console.WriteLine(json);
            }
        }
    }

    public void CreateGroup(int Id)
    {
        _groupData.Add(new Group(Id));
    }

    public void AddToGroup(int taskId, int groupId)
    {
        foreach (var t in _taskData)
        {
            if (t.TaskId == taskId)
            {
                foreach (var t1 in _groupData)
                {
                    if (t1.GroupId == groupId)
                    {
                        t1.Tasks.Add(t);
                    }
                }
            }
        }
    }

    public void ShowGroup()
    {
        foreach (var t in _groupData)
        {
            var json = JsonSerializer.Serialize(t!.GroupId);
            var json1 = JsonSerializer.Serialize(t!.Tasks);
            Console.WriteLine(json);
            Console.WriteLine(json1);
        }
    }

    public void DeleteGroup(int Id)
    {
        var group = _groupData.Single(group => group.GroupId == Id);
        _groupData.Remove(group);
    }

    public void DeleteTaskFromGroup(int groupId, int taskId)
    {
        foreach (var group in _groupData.Where(t => t.GroupId == groupId))
        {
            for (var j = 0; j < _taskData.Count; ++j)
            {
                if (_taskData[j].TaskId == taskId)
                {
                    group.Tasks.Remove(group.Tasks[j]);
                }
            }
        }
    }
    
    
}