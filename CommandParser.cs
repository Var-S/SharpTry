namespace SectTask;

public class CommandParser
{
    public void Commands(string?[] args)
    {
        TaskManager td = new TaskManager();
        for (int i = 0; i < args.Length - 1; ++i)
        {
            if (args[i] is null)
            { 
                return;
            } 
            switch (args[i]) 
            { 
                case "/add": 
                    td.AddTask(Convert.ToInt32(args[i + 4]), Convert.ToDateTime(args[i + 5]),Convert.ToBoolean(args[i + 6])); 
                    break;
                case "/all": 
                    td.ShowTasks(); 
                    break;
                case "/delete": 
                    td.DeleteTask(Convert.ToInt32(args[i + 1])); 
                    break;
                case "/save": 
                    td.toFile(args[i + 1]); 
                    break;
                case "/load": 
                    td.fromFile(args[i + 1]); 
                    break;
                case "/completed": 
                    td.ChangeTaskStatus(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2])); 
                    break;
                case "/create-group": 
                    td.CreateGroup(Convert.ToInt32(args[i + 1])); 
                    break;
                case "/delete-group": 
                    td.DeleteGroup(Convert.ToInt32(args[i + 1])); 
                    break;
                case "/add-to-group": 
                    td.AddToGroup(Convert.ToInt32(args[i + 1]), Convert.ToInt32(args[i + 2])); 
                    break;
                case "/delete-from-group": 
                    td.DeleteTaskFromGroup(Convert.ToInt32(args[i + 1]), Convert.ToInt32(args[i + 2])); 
                    break;
                case "/add-subtask": 
                    SubTask sub1 = new SubTask(Convert.ToBoolean(args[i + 1]), Convert.ToInt32(args[i + 2]), args[i + 3], args [i + 4]); 
                    td.AddSubTask(Convert.ToInt32(args[i + 5]),sub1); 
                    break;
                case "/change-sub-status": 
                    td.ChangeSubtaskStatus(Convert.ToInt32(args[i + 1]), Convert.ToInt32(args[i + 1])); 
                    break;
                case "/today":
                    td.PrintTodaysDeadline(); 
                    break;
            }
        }
    }
}