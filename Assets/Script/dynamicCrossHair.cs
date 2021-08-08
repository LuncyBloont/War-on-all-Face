using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicCrossHair : MonoBehaviour
{
    public GameObject body;
    Vector3 startScale;

    float scaleLimit = 2;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = startScale * 
            (1 + Vector3.Distance(new Vector3(0, 0, 0), body.GetComponent<Rigidbody>().velocity) / 40);
        if (Vector3.Distance(new Vector3(0, 0, 0), transform.localScale) >
            Vector3.Distance(new Vector3(0, 0, 0), startScale) * scaleLimit)
        {
            transform.localScale = startScale * scaleLimit;
        }
    }
}
