using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    [SerializeField] string ipAddress = "127.0.0.1";
    public static Endpoint instance;
    enum ServerType { Dev, Stage, Prod }
    [SerializeField] ServerType serverType; 
    enum ProtocolType { http, https }
    [SerializeField] ProtocolType protocol; 
    public enum EndPointType { AddUser, GetUser, GetAllUsers }
    [SerializeField] EndPointType endPointType;

    int GetPort()
    {
        switch (serverType)
        {
            case ServerType.Dev:
                return 3000;
            case ServerType.Stage:
                return 3100;
            case (ServerType.Prod):
                return 3200;
            default:
                return 3000;
        }
    }
    string GetProtocol()
    {
        switch (protocol)
        {
            case ProtocolType.http:
                return "http";
            case ProtocolType.https:
                return "https";
            default:
                return "https";
        }
    }

    public string AddUserEndpoint
    {
        get { return $"{GetProtocol()}://{ipAddress}:{GetPort()}/add-user"; }
    }
    public string GetUserEndpoint
    {
        get { return $"{protocol}://{ipAddress}:{GetPort()}/add-user"; }
    } 
    public string GetAllUsers
    {
        get { return $"{protocol}://{ipAddress}:{GetPort()}/add-user"; }
    }

    private void Start()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
