using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("Tap escape into keyboard!!!");
            Application.Quit();
        }
    }
}
