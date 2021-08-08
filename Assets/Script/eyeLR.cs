using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeLR : MonoBehaviour
{
    public float y_sy = 8f;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * y_sy, 0, Space.Self);
    }
}
