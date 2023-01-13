using UnityEngine;
using Firebase.Database;
using System.Collections;

using UnityEngine.UI;


public class DataBase : MonoBehaviour
{
    private DatabaseReference dbRef;
    [SerializeField] private string IDLink;
    private string nowLink;
    public InputField input;
    private DataBase dataBase;
    void Start()
    {
        dataBase = GetComponent<DataBase>();
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }
    
    public string GetTextLink()
    {
        StartCoroutine(LoadData(IDLink));
        return nowLink;
    }

    public IEnumerator LoadData(string str)
    {
        var textLink = dbRef.Child(str).GetValueAsync();
        yield return new WaitUntil(predicate: () => textLink.IsCompleted);

        if (textLink.Exception != null)
        {
            Debug.Log(textLink.Exception);
        }
        else if(textLink.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = textLink.Result;
            Debug.Log("Новая ссылка: "+ snapshot.Value.ToString());
            nowLink = snapshot.Value.ToString();
            
        }
    }
}
