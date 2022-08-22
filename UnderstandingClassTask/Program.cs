using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnderstandingClassTask
{
    internal class Program
    {
        static void Main()
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                    Task.CurrentId, obj,
                                    Thread.CurrentThread.ManagedThreadId);
            };

            Task t1 = new Task(action, "alpha"); //t1 é instanciado chanmado um construtor da class ...L26

            Task t2 = Task.Factory.StartNew(action, "beta");
            t1.Wait(); //A t2 é instanciada e iniciada em uma unica chamada de metodo

            t1.Start(); // ... mais é iniciado so apos a t2
            Console.WriteLine("t1 has been launched. (Main Thread={0})",
                                Thread.CurrentThread.ManagedThreadId);
            t1.Wait();

            String taskData = "delta";
            Task t3 = Task.Run(() =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                    Task.CurrentId, taskData,
                                    Thread.CurrentThread.ManagedThreadId);
            });// t3 e instanciada e iniciada em uma unica chamada de metodo 
            t3.Wait();

            Task t4 = new Task(action, "gamma");
            t4.RunSynchronously(); // t4 é executada de forma sincrona no thread principal
            t4.Wait();
            //obs: as tarefas sao executadas de forma assincrona, normalmente em um ou mais thread do pool de threads
        }
        // ex 2
        //public static async Task Main()
        //{
        //    await Task.Run(() =>
        //    {
        //        int ctr = 0;
        //        for (ctr = 0; ctr < 10; ctr++)
        //        {

        //        }
        //        Console.WriteLine($"Finished {ctr} loop iterations");
        //    });
        //    Console.ReadKey();
        //}
        // ex 3
        //public static void Main()
        //{//mesma coisa mais com metodos diferentas
        //    Task t = Task.Factory.StartNew(() =>
        //    {
        //        int ctr = 0;
        //        for (ctr = 0; ctr < 10; ctr++)
        //        {

        //        }
        //        Console.WriteLine($"Finished {ctr} loop iterations");
        //    });
        //    Console.ReadKey();
        //}
    }
}
