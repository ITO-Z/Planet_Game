using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Path : MonoBehaviour
{
    public Text pathText;
    void Start()
    {
        pathText.text = Application.persistentDataPath;
    }
}
