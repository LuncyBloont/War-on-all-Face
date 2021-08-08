using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rePos : MonoBehaviour
{
    public inWater iw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "repos")
        {
            iw.rePoint = other.gameObject.transform;
            other.gameObject.transform.localScale = new Vector3(0, 0, 0);
            other.tag = "effect";
            iw.suc += 1;
        }
    }
}
