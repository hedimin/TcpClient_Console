# TcpClient_Console
This is a TCP/IP socket type client.

# Working principle
![Діаграма без назви drawio](https://user-images.githubusercontent.com/112476754/205778038-2de736a7-ae84-4b1f-8efb-7bd89e62379a.png)

# How it works?
 It connects to the server via any IP and 8888 port:
```C#
using TcpClient tcpClient = new TcpClient();
await tcpClient.ConnectAsync("127.1.199.250",8888);
```
After starting and creating the client, programm informs about it and asks to enter user's name:

![image](https://user-images.githubusercontent.com/112476754/205513921-5d915f23-c352-4b98-9d94-3bd0dd5a59a0.png)

and user's message, after what sends data to the server and informs about it:

![image](https://user-images.githubusercontent.com/112476754/205514031-40957323-9040-4bb4-ace0-2fdc98f742b1.png)

The data is serealized using Messagepack, where person - object of custom type Person, that is created after entered data from console:

```C#
var sentData = MessagePackSerializer.Serialize(person);
```

