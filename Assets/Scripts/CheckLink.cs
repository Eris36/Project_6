using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CheckLink : MonoBehaviour
{
    
    public string filelink = "link.li";
    private string textLink;
    private StreamWriter sw;
    // Start is called before the first frame update
    
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
