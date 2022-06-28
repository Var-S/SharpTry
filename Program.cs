namespace SectTask;

static class Program
{
    static void Main(string?[] args)
    {
        CommandParser input = new CommandParser();
        input.Commands(args);
        
       /* TaskManager td = new TaskManager();
        SubTask subTask = new SubTask(false, 1,"sport", "beerpong") ;
        SubTask subTask1 = new SubTask(false, 2,"sprt", "beerpong") ;
        SubTask subTask2 = new SubTask(false, 3,"port", "beerpong") ;

        td.AddTask(1,DateTime.Now, true);
        td.AddTask(2,DateTime.Now, true);
        td.AddTask(3,DateTime.Now, true);

        td.ShowTasks();
        Console.WriteLine();
        td.ChangeTaskStatus(1, false);
        td.ShowTasks();
        Console.WriteLine();
        td.ChangeSubtaskStatus(1, 1);
        td.ShowTasks();
        td.AddSubTask(1,subTask);
        td.AddSubTask(1,subTask1);
        td.AddSubTask(1,subTask2);
        td.CreateGroup(1);
        td.AddToGroup(1,1);
        td.AddToGroup(2,1);
        Console.WriteLine();
        //td.ShowTasks();

        td.ShowGroup();
        td.DeleteTaskFromGroup(1,2);
        td.ShowGroup();
        td.DeleteGroup(1);
        td.ShowGroup();*/
    }
}