using System.Diagnostics;

namespace AsyncAwaitBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call PerformCalculations and measure time taken using Stopwatch
            int numberOfTasks = 5;
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Starting calculations...");
            stopwatch.Start();
            await PerformCalculations(numberOfTasks);
            stopwatch.Stop();
            Console.WriteLine($"Total time taken: {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        static async Task SimulateLongRunningTask(int delayInSeconds)
        {
            // Implement long-running task simulation
            await Task.Delay(delayInSeconds * 1000);
            Console.WriteLine($"Task with delay of {delayInSeconds} seconds completed");
        }

        static async Task PerformCalculations(int numberOfTasks)
        {
            // Start long-running tasks concurrently and wait for them to complete]
            Console.WriteLine($"Starting {numberOfTasks} tasks...");
            Task[] tasks = new Task[numberOfTasks];

            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks[i] = SimulateLongRunningTask(i + 1);
            }

            await Task.WhenAll(tasks);
            Console.WriteLine($"All {numberOfTasks} tasks completed");
        }
    }
}