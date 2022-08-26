using UnityEngine;
using System.Net.Sockets;
using System.Net;
using Core;
using UnityEngine.UI;
using System;

public class NetworkManager : MonoBehaviour
{
    Socket socket;
    Player player;

    [SerializeField] GameObject connect;
    [SerializeField] InputField playerName;

    [SerializeField] GameObject chatRoom;
    [SerializeField] Button connectButton;
    [SerializeField] Button sendButton;
    [SerializeField] InputField chatField;

    delegate void ConnectedToServer();
    ConnectedToServer ConnectedEvent;
    void Start()
    {
        connectButton.onClick.AddListener(() =>
        {
            try
            {
                player = new Player(Guid.NewGuid().ToString(), playerName.text);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000));
                socket.Blocking = false;
                
                connect.SetActive(false);
                chatRoom.SetActive(true);

                if (ConnectedEvent != null)
                    ConnectedEvent();
            }
            catch (SocketException ex)
            {
                print(ex);
            }
        });
        sendButton.onClick.AddListener(() =>
        {
            socket.Send(new MessagePacket(chatField.text, player).Serialize());
        });
    }

    /*void Update()
    {
        if (socket.Available > 0)
        {
            byte[] receivedBuffer = new byte[socket.Available];
            socket.Receive(receivedBuffer);

            BasePacket bp = new BasePacket().Deserialize(receivedBuffer);

            switch (bp.type)
            {
                case BasePacket.PacketType.Message:
                    MessagePacket mp = (MessagePacket)new MessagePacket().Deserialize(receivedBuffer);
                    print($"{mp.player.Name} said: {mp.Message}");
                    break;
                default:
                    break;
            }
        }
    }*/
}
