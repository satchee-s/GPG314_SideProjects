using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindUsers : MonoBehaviour
{
    private void Awake()
    {
        Http.responseEvent += FindAllUsers;
    }
    private void OnDestroy()
    {
        Http.responseEvent += FindAllUsers;
    }
    public void ReturnUsersInDatabase()
    {
        StartCoroutine(Http.Get(Endpoint.instance.GetAllUsers, ""));
    }
    void FindAllUsers(string jsonResponse, bool successful)
    {
        if (successful)
            Debug.Log("Successful");
        else
            Debug.Log("Not successful");
        Debug.Log(jsonResponse);
        AllUsers users = JsonUtility.FromJson<AllUsers>(jsonResponse);
        for (int i = 0; i < users.users.Length; i++)
        {
            Debug.Log(users.users[i].Username);
        }
    }
}
