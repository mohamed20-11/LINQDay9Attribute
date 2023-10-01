using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Check
{
    public Random random = new Random();

    [Verb("GET")]
    public void Get()
    {
        Console.WriteLine("WE GET TAIRED ");
        Thread.Sleep(random.Next(1500));
    }
}
