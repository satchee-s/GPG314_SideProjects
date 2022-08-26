using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Core;

namespace Server
{
    internal class ServerProgram
    {
        static void Main(string[] args)
        {
            Socket listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listeningSocket.Bind(new IPEndPoint(IPAddress.Any, 3000));
            listeningSocket.Listen(10);
            listeningSocket.Blocking = false;

            Console.WriteLine("Waiting...");
            List<Socket> client = new List<Socket>();

            while (true)
            {
                try
                {
                    client.Add(listeningSocket.Accept());
                    Console.WriteLine("Client connected to server");

                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode != SocketError.WouldBlock)
                        Console.WriteLine(ex);
                }

                for (int i = 0; i < client.Count; i++)
                {
                    try
                    {
                        if (client[i].Available > 0)
                        {
                            byte[] receivedBuffer = new byte[client[i].Available];
                            client[i].Receive(receivedBuffer);

                            BasePacket bp = new BasePacket().Deserialize(receivedBuffer);
                            client[i].Send(receivedBuffer);
                        }
                    }
                    catch (SocketException ex)
                    {
                    }

                } 
            } 
        }
    }
}


/*string input = Console.ReadLine();
 
 MessagePacket mp = (MessagePacket)new MessagePacket().Deserialize(receivedBuffer);
Console.WriteLine($"{mp.player.Name} said: {mp.Message}");
if (input != null)
{
    try
    {
        // client[i].Send(new InstantiatePacket(input, player).Serialize());
        client[i].Send(new MessagePacket(input, player).Serialize());
        Console.WriteLine("message sent to client");
    }
    catch (SocketException ex)
    {
        if (ex.SocketErrorCode == SocketError.ConnectionAborted ||
            ex.SocketErrorCode == SocketError.ConnectionReset)
        {
        }
        else
            Console.WriteLine(ex);
    }
}*/