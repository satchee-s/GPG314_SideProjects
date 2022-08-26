using UnityEngine;
using UnityEngine.UI;
using System;

public class AddUser : MonoBehaviour
{
    [SerializeField] InputField playerName;
    [SerializeField] InputField playerPassword;
    [SerializeField] InputField playerID;
    [SerializeField] InputField playerScore;

    private void Awake()
    {
        Http.responseEvent += ResponseEvent;
    }

    private void OnDestroy()
    {
        Http.responseEvent -= ResponseEvent;
    }

    public void AddUserToDatabase()
    {
        int score = Int32.Parse(playerScore.text);
        User user = new User(playerName.text, playerPassword.text, playerID.text, score);
        string json = JsonUtility.ToJson(user);
        Http.responseEvent += ResponseEvent;
        StartCoroutine(Http.Post(Endpoint.instance.AddUserEndpoint, json));
    }

    private void ResponseEvent(string jsonResponse, bool successful)
    {
        if (successful)
            Debug.Log("Successful");
        else
            Debug.Log("Not successful");
        Debug.Log(jsonResponse);

    }
}
