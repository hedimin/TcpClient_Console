using MessagePack;

namespace TcpClient_Console.IntegrationTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ConnectsToTheServer()
    {
        //Arrange
        var tcpListener = new TcpListener(IPAddress.Any, 8888);
        //Act
        try
        {
            tcpListener.Start();
            using var tcpClient = await tcpListener.AcceptTcpClientAsync();
        }
        catch (Exception e)
        {
            //Assert
            Assert.That(e == null, Is.EqualTo(true));
        }
    }
    [Test]
    public async Task SendsData()
    {
        //Arrange
        var tcpListener = new TcpListener(IPAddress.Any, 8888);
        //Act
        try
        {
            tcpListener.Start();
            using var tcpClient = await tcpListener.AcceptTcpClientAsync();
            await using var stream = tcpClient.GetStream();
        }
        catch (Exception e)
        {
            //Arrange
            Assert.That(e == null, Is.EqualTo(true));
        }
    }

    [Test]
    public void SerealizesData()
    {
        //Arrange
        var tom = new Person("Tom", "Tom's message");
        var tomBytes = MessagePackSerializer.Serialize(tom);
        //Act
        var deserealizedTom = MessagePackSerializer.Deserialize<Person>(tomBytes);
        //Assert
        Assert.That(tom.Name == deserealizedTom.Name && tom.Message == deserealizedTom.Message, Is.EqualTo(true));
    }
}