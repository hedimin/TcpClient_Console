using System.Net.Sockets;
using MessagePack;

//Starting client
using TcpClient tcpClient = new TcpClient();
await tcpClient.ConnectAsync("127.1.199.250",8888);

Console.WriteLine("Hello, client!");

try
{
    //Getting stream to write data
    await using var stream = tcpClient.GetStream();
    
    //Making data - Person type object
    Console.WriteLine("Enter your name");
    var name = Console.ReadLine();
    Console.WriteLine("Enter message");
    var message = Console.ReadLine();
    Person person = new Person(name, message);

    //Serializing data 
    var sentData = MessagePackSerializer.Serialize(person);
    
    //Writing data to the stream
    await stream.WriteAsync(sentData);
    Console.WriteLine("Message was sent to the server");
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//Type for de/serealizing
[MessagePackObject]
public class Person
{
    [Key(0)]
    public string Name { get; set; }
    [Key(1)]
    public string Message { get; set; }

    public Person(string name, string message)
    {
        Name = name;
        Message = message;
    }
}