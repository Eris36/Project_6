using UnityEngine;
using System.IO;



public class CheckLink : MonoBehaviour
{
    
    public string filelink = "link.li";
    private string textLink;
    private StreamWriter sw;

    public string SearchLink()
    {
        if (!File.Exists(filelink))
        {
            sw = new StreamWriter(filelink);
        }
        
        int n = File.ReadAllLines(filelink).Length;
        if (n > 0)
        {
             textLink = File.ReadAllLines(filelink)[0];
             return textLink;
        }
        else
        {
            return null;
        }
    }

}
