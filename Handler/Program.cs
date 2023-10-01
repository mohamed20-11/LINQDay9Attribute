
using System;
using System.Diagnostics.Metrics;
using System.IO;

using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

public class Program
{
    public static string urlMsg = "url.txt";
    public static Mutex mutex = new Mutex();
    public static void Handle()
    {
        
        string url = string.Empty;
        mutex.WaitOne();
        FileStream fs = new FileStream(urlMsg,
        FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        StreamReader reader = new StreamReader(fs);
        url = reader.ReadToEnd();
        mutex.ReleaseMutex();
        string[] urlSegments = url.Split('/');
        string verbName = urlSegments[0];
        string className = urlSegments[1];
        string methodName = urlSegments[2];
        Type type =
            Assembly.GetExecutingAssembly()
                    .GetType(className);
        if (type != null)
        {
            MethodInfo info = type.GetMethod(methodName);
            if (info != null)
            {
                object obj = Activator.CreateInstance(type);
                Verb V  = info.GetCustomAttribute(typeof(Verb)) as Verb;
                if(V.Name == verbName)
                {
                    info.Invoke(obj, null);
                }
            }
        }
    }
    public static void Main()
    {
        /*
         
            Synchronous - Sequentioal 
            Asynchronous 
            Paralell 
         */
        bool valid = true;
        Console.WriteLine("Opened");
        Console.CancelKeyPress += (s, e) =>
        {
            valid = false;
        };
        //int i = 0;
        //Thread[] threads = new Thread[11];
        while (valid)
        {
            ThreadPool.QueueUserWorkItem(e =>
            {
                Handle();
            });


            //threads[i] = new Thread(Handle);
            //threads[i].IsBackground = true;
            //threads[i].Start();

            //if (i == 10)
            //    break;

            //Handle();
           // i++;
        }


        //for (int j = 0; j < 11; j++)
        //    threads[j].Join();

        Console.WriteLine("Closed");
    }
}