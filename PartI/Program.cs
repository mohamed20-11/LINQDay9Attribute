#define BEBUGGING
#undef BEBUGGING


using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using PartI;

[assembly: AssemblyVersion("1.0.0.0")]




public class Programb
{

    [Obsolete("Please Use EnhancedPrintMessage() Instead", true)]
    public static void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    public static void EnhancedPrintMessage(string message)
    {
        Console.SetCursorPosition(
            (Console.WindowWidth - message.Length) / 2,
            0
            );
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    public static void ShowCustomers()
    {
        PosContext db = new PosContext();
        foreach (Customer c in db.Customers)
            Console.WriteLine(c.Name);
    }
    public static void SerializeObject()
    {
        Customer c = new Customer()
        {
            Id = 1,
            Name = "Ahmed"
        };
        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();
        #pragma warning disable
        bf.Serialize(stream, c);
        FileStream fs = new FileStream
            ("info.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        stream.Seek(0, SeekOrigin.Begin);
        stream.CopyTo(fs);
        fs.Flush();
        fs.Close();

    }

    [Conditional("BEBUGGING")]
    public static void DeSerializeObject()
    {
        FileStream fs = new FileStream("info.dat",
           FileMode.Open, FileAccess.Read);
        MemoryStream stream = new MemoryStream();
        StreamReader reader = new StreamReader(fs);
        fs.CopyTo(stream);
        stream.Seek(0, SeekOrigin.Begin);
        BinaryFormatter bf = new BinaryFormatter();
        Console.WriteLine((bf.Deserialize(stream) as Customer).Name);
    }
   
    public static void Main()
    {
        Customer customer = new Customer();
    }
}