using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeUD : MonoBehaviour
{
    public float x_sy = 8f;

    public float upE = 0;

    float backUp = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Input.GetAxis("Mouse Y") * x_sy, 0, 0, Space.Self);
        if (transform.localEulerAngles.x > 90)
        {
            transform.Rotate(Input.GetAxis("Mouse Y") * x_sy, 0, 0, Space.Self);
        }
        transform.Rotate(-upE, 0, 0, Space.Self);
        upE *= Mathf.Pow((1 - backUp), Time.deltaTime * 1000);
    }
}
