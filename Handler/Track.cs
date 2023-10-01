using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Track
{
    public Random random = new Random();

    [Verb("GET")]
    public void Get()
    {
        Console.WriteLine("Inside Get Track ");
        Thread.Sleep(random.Next(1000));
    }
}
