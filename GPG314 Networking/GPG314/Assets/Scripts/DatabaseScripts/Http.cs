using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class Http
{
    public delegate void HTTPResponse(string jsonResponse, bool isSuccessful);
    public static event HTTPResponse responseEvent;

    static IEnumerator CallHTTP(string url, string json, string method)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, method))
        {
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(buffer);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            bool success = request.error == null ? true : false;
            responseEvent(request.downloadHandler.text, success);
        }
    }

    public static IEnumerator Post(string url, string json)
    {
        yield return CallHTTP(url, json, "POST");
    }

    public static IEnumerator Get(string url, string urlEncoding)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(url + urlEncoding))
        {
            req.SetRequestHeader("Content-Type", "application/json");
            yield return req.SendWebRequest();
            bool sucessful = req.error == null ? true : false;
            responseEvent(req.downloadHandler.text, sucessful);
        }
    }
}
