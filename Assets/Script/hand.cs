using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    public float limit = 5;
    public GameObject body;
    public float speed = 1;
    public float sinRate = 0.4f;
    public float sinSpeed = 0.06f;
    Vector3 sourcePosition;
    Vector3 oldBodyTo;

    float sini = 0;


    // Start is called before the first frame update
    void Start()
    {
        sourcePosition = transform.localPosition;
        oldBodyTo = body.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        sini += sinSpeed * Time.deltaTime;
        float disR = Vector3.Distance(body.transform.forward, oldBodyTo) * Input.GetAxis("Mouse X");
        Vector3 ttf = new Vector3(
            Vector3.Dot(transform.right, body.GetComponent<Rigidbody>().velocity),
            Vector3.Dot(transform.forward, body.GetComponent<Rigidbody>().velocity),
            -Vector3.Dot(transform.up, body.GetComponent<Rigidbody>().velocity)
        ) * (Mathf.Sin(sini) * sinRate + 1 - sinRate) + new Vector3(1, 0, 0) * disR * speed * 100;
        if (Vector3.Distance(new Vector3(0 ,0 ,0), ttf) > limit)
        {
            ttf = ttf.normalized * limit;
        }
        Vector3 tof = sourcePosition - ttf / 60;
        Vector3 k = tof * speed / 10 / (- speed / 10);
        transform.localPosition = (transform.localPosition + k) 
            * Mathf.Pow(1 - speed / 10, Time.deltaTime * 60) - k;
        oldBodyTo = body.transform.forward;
    }
}
