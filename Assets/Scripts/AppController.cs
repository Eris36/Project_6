using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField] private CheckInternet CheckInternet;
    [SerializeField] private CheckLink CheckLiks;

    private db dataBase;
    private string link;

    [SerializeField] private string[] urls;
    [SerializeField] private bool isInternet;
    
    private void Start()
    {
        link = CheckLiks.SearchLink();
        dataBase = GetComponent<db>();

        if (link != null)
        {
            Debug.Log("Сылка есть: " + link);
            //Открывает заглушку (игру или сервис) по ссылке
        }
        else
        {
            Debug.Log("Сылки нету");
            if (dataBase.GetTextLink() == ""); ///Остановился на проверки

        }
        
        Debug.Log("link: " + link );
        isInternet = CheckInternet.TestConnection();
        Debug.Log("isInternet: " + isInternet );
    }
    
    
    
}
