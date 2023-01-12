using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class CheckInternet : MonoBehaviour
{
    [SerializeField] private string[] urls;
    [SerializeField] private bool isInternet;
    
    public bool TestConnection()
    {
        foreach (string url in urls)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);

            if (request.isNetworkError == false)
            {
                return true;
            }
        }
        return false;
    }
}
