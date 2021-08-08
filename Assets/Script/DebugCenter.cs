using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCenter : MonoBehaviour
{
    // public int FPS = 20;
    // Start is called before the first frame update
    void Start()
    {
        // Application.targetFrameRate = FPS;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.E))
        {
            Application.Quit();
        }
    }
}
