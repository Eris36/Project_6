using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
    //Для проверки ссылки на устройстве
    [SerializeField] private CheckLink CheckLiks;
    private string link;
    
    //FireBase
    private DataBase dataBase;
    
    //Для проверки доступа сети
    [SerializeField] private string[] urls;
    public GameObject UIIsNotInet;
    private bool isInet = false;
    
    
    
    private void Start()
    {
        link = CheckLiks.SearchLink();
        dataBase = GetComponent<DataBase>();

        if (link != null)
        {
            //Если ссылка на устройстве есть открывает заглушку (игру или сервис) по ссылке
            Debug.Log("Сылка есть: " + link);
            if (!isInet)
            {
                TestInet();
            }
        }
        else
        {
            //Если ссылки нету, лезем на сервер за ссылкой
            Debug.Log("Сылки нету");
            string nowLink =  dataBase.GetTextLink();
            if (nowLink == "" || IsEmulator() || IsNoSim())
            {
                SceneManager.LoadScene("Landing");
            }
            else
            {
                
            }
        }
        Debug.Log("link: " + link);
        
    }

    //Тестируем соединение с интернетом Корутиной.
    public void TestInet()
    {
        StartCoroutine(CheckInternetConnection(isConnected =>
        {
            if (isConnected)
            {
                isInet = true;
            }
            else
            {
                UIIsNotInet.SetActive(true);
            }
        }));
    }
    
    //Посылаем запрос до указанного ресурса, дожидаясь ответа.
    IEnumerator CheckInternetConnection(Action<bool> action)
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null) {
            action (false);
        } else{
            UIIsNotInet.SetActive(false);
            action (true);
        }
    }

    //Проверка типа устройства на Эмуляцию приложения
    private bool IsEmulator()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsNoSim()
    {
        return true;
    }
    
    public void ExitPressed()
    {
        Application.Quit();
    }
}
















