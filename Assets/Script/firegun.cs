using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firegun : MonoBehaviour
{
    public Animator ani;
    public float end = 2;
    float end_i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && end_i >= end)
        {
            GetComponent<fire>().Fire();
            ani.SetFloat("Fire", 1);
            ani.Play("fireOn", 0, 0);
            ani.Update(0);
            end_i = 0;
        }
        
        if (end_i > end)
        {
            end_i = end;
            ani.SetFloat("Fire", 0);
        }
        end_i += 1 * Time.deltaTime;
    }
}
