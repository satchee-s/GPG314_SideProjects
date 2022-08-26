using UnityEngine;

public class User
{
    public string Username;
    public string Password;
    public string PlayerId;
    public int Score;

    public User(string name, string password, string playerId, int score)
    {
        Username = name;
        Password = password;
        PlayerId = playerId;
        Score = score;
        User user = new User(name, password, playerId, score);
        
        string json = JsonUtility.ToJson(user);
        Http.Post(Endpoint.instance.GetUserEndpoint, json);
    }
}
