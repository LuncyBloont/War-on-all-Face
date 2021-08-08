using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot_hit : MonoBehaviour
{
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "effect" || other.tag == "water") return;
        body.GetComponent<MoveAble>().OnStayFloor();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "effect" || other.tag == "water") return;
        // Debug.Log("Hello");
        body.GetComponent<MoveAble>().OnHitFloor();
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "effect" || other.tag == "water") return;
        // Debug.Log("Bye");
        body.GetComponent<MoveAble>().OnLeaveFloor();
    }
}
