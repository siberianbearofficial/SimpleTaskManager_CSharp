using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager_CSharp
{
    public class TaskManagerHolder
    {
        public static void Start()
        {
            while (true)
            {
                Console.Write("command>> ");
                string command = Console.ReadLine();
                if (command.ToLower().Contains("help"))
                {
                    if (command.ToLower() == "help")
                    {
                        TaskManager.Help();
                    }
                    else
                    {
                        TaskManager.Help(command.Split(" ")[1]);
                    }
                }
                else if (command.ToLower() == "exit")
                {
                    break;
                }
                else if (command.ToLower().Contains("killbyid"))
                {
                    if (command.ToLower() == "killbyid")
                    {
                        TaskManager.Help("killbyid");
                    }
                    else
                    {
                        TaskManager.KillTaskById(int.Parse(command.Split(" ")[1]));
                    }
                }
                else if (command.ToLower().Contains("killbyname"))
                {
                    if (command.ToLower() == "killbyname")
                    {
                        TaskManager.Help("killbyname");
                    }
                    else
                    {
                        TaskManager.KillTaskByName(command.Split(" ")[1]);
                    }
                }
                else if (command.ToLower() == "tasklist")
                {
                    TaskManager.PrintAllTasks();
                }
                else if (command.ToLower().Contains("processid"))
                {
                    if (command.ToLower() == "processid")
                    {
                        TaskManager.Help("processid");
                    }
                    else
                    {
                        TaskManager.FindTask(command.Split(" ")[1]);
                    }
                }
                else
                {
                    Console.WriteLine("There is no command with the specified name. Use help command to see instructions.");
                }
            }
        }
    }
}
