using System;
using System.Threading;
using System.Threading.Tasks;

namespace SoftHard.Papirus.ConsoleClient
{
    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            System.Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Start.");

            await AsyncAwaitTest();

             Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

/* 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            System.Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Start.");

            Task.Run(()=>AsyncAwaitTest());

            //  ThreadTests();
            //  TasksTest();

            // decimal amount = TaxCalculate(100);
            // decimal amount2 = TaxCalculate(amount);

           // ContinueWithTest();

            //  System.Console.WriteLine( task.Result);

            System.Console.WriteLine("Hello");


            // Send();

            // Send();



            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();


        }

        */

        private static void ContinueWithTest()
        {
            var task = TaxCalculateAsync(100)
                .ContinueWith(t => TaxCalculate(t.Result))
                   .ContinueWith(t => System.Console.WriteLine(t.Result));
        }

        
        private static void SynchrTest()
        {
            decimal amount = TaxCalculate(100);
            decimal amount2 = TaxCalculate(amount);

            System.Console.WriteLine(amount2);
        }

        private static async Task AsyncAwaitTest()
        {

            CancellationTokenSource cts = new CancellationTokenSource();

            CancellationToken token = cts.Token;

            IProgress<int> progress = new Progress(i=>System.Console.WriteLine($"Step {i}"));

            decimal amount  = await TaxCalculateAsync(100, token, progress).ConfigureAwait(false);
            decimal amount2 = await TaxCalculateAsync(amount, token, progress);

            // textbox1.Text = amount2;

            System.Console.WriteLine(amount2);

                // .ContinueWith(t => TaxCalculate(t.Result))
                //    .ContinueWith(t => System.Console.WriteLine(t.Result));
        }


        private static async Task CalculateParallerTest()
        {
            var task1 = Task.Run(() => TaxCalculateAsync(100));

            var task2 = Task.Run(() => TaxCalculateAsync(100));

            await Task.WhenAll(task1, task2);

            System.Console.WriteLine(task1.Result  + task2.Result);

         



        }


        private static void TasksTest()
        {
            CancellationTokenSource source = new CancellationTokenSource();

            CancellationToken token = source.Token;

            Task task1 = Task.Run(() => Send(token));

            Task task2 = Task.Run(() => Send(token));

            Task.WaitAll(task1, task2);

            Thread.Sleep(TimeSpan.FromSeconds(6));

            Task task3 = Task.Run(() => Send());
        }

        private static void Send()
        {
            throw new NotImplementedException();
        }

        private static void ThreadTests()
        {
            Thread thread = new Thread(Send);
            thread.IsBackground = true;

            thread.Start();

            Thread thread2 = new Thread(Send);
            thread2.IsBackground = true;
            thread2.Start();
        }

        static void Send(CancellationToken token)
        {

         
            System.Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sending...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            System.Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sent.");

        }


        static Task<decimal> TaxCalculateAsync(decimal amount, CancellationToken token = null, IProgress<int> progress = null)
        {
            return Task.Run(()=>TaxCalculate(amount, token, progress));
        }


        static decimal TaxCalculate(decimal amount, 
            CancellationToken token = null,
            IProgress<int> progress = null
            )
        {
            System.Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculating...");

            for(int i=0; i<5; i++)
            {
                if (token!=null && token.IsCancellationRequested)
                {
                    break;
                }
            
                Thread.Sleep(TimeSpan.FromSeconds(1));

                progress?.Report(i);
            }
            System.Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculated.");

            return amount+10;

        }



    }
}
