using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Ch24Ex04
{
    internal class Program
    {
        private static void MyTask()
        {
            WriteLine($"MyTask() №{Task.CurrentId} запущен.");

            for (var count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                WriteLine($"В методе MyTask() №{Task.CurrentId}, подсчёт равен {count}");
            }

            WriteLine($"MyTask №{Task.CurrentId} завершён.");
        }

        private static void Main()
        {
            WriteLine("Основной поток выполнения запущен.");

            // Здесь идёт объявление задач, которые могут выполняться параллельно.
            var task01 = new Task(MyTask);
            var task02 = new Task(MyTask);

            WriteLine($"Идентификатор задачи task01: {task01.Id}");
            WriteLine($"Идентификатор задачи task02: {task02.Id}");

            // Здесь идёт запуск задач, которые начинают выполняться параллельно. 
            task01.Start();
            task02.Start();
            
            Task.WaitAll(task01, task02);

            WriteLine("Основной поток завершён.");
        }
    }
}
