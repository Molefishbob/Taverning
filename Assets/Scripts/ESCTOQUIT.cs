using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCTOQUIT : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitted");
            Application.Quit();
        }
    }
}
