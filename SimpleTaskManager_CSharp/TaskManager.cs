using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager_CSharp
{
    public class TaskManager
    {
        private static Dictionary<string, string> help_instructions = new Dictionary<string, string>()
        {
            {"exit", "Closes the program"},
            {"killbyid", "Kills the process with the specified id"},
            {"killbyname", "Kills all processes with the specified name"},
            {"tasklist", "Prints all active processes"},
            {"processid", "Prints all processes with the specified name or only part of the name (case insensitive)"},
            {"help", "Prints instructions for all commands or for the specified one"}
        };

        public static void Help(string command=null)
        {
            if (command is null)
            {
                foreach (KeyValuePair<string, string> kvp in help_instructions)
                    Console.WriteLine($"{kvp.Key, 10} {kvp.Value}");
            } else
            {
                string instr;
                help_instructions.TryGetValue(command, out instr);
                if (instr is null)
                    Console.WriteLine("There is no command with the specified name");
                else
                    Console.WriteLine(instr);
            }
        }

        public static void FindTask(string Str)
        {
            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                if (task_list[i].ProcessName.ToLower().IndexOf(Str.ToLower()) >= 0)
                {
                    Console.WriteLine($"{task_list[i].Id,7}   {task_list[i].ProcessName}");
                }
            }

        }

        public static void KillTaskById(int Id)
        {
            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                if (task_list[i].Id == Id)
                {
                    task_list[i].Kill();
                    break;
                }
            }
        }

        public static void KillTaskByName(string TaskName)
        {
            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                if (task_list[i].ProcessName == TaskName)
                {
                    task_list[i].Kill();
                }
            }
        }

        public static void PrintAllTasks()
        {
            var task_list = Process.GetProcesses();
            for (int i = 0; i < task_list.Length; i++)
            {
                Console.WriteLine($"{task_list[i].Id,7}   {task_list[i].ProcessName}");
            }

        }
    }
}