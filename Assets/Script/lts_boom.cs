using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lts_boom : MonoBehaviour
{
    public GameObject mod;
    public float size = 4;
    GameObject modi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void boomStart()
    {
        modi = Instantiate(mod, transform.position, transform.rotation);
        modi.transform.localScale = new Vector3(1, 1, 1) * size;
        
    }
}
