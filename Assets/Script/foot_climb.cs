using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot_climb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject body;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "effect") return;
        body.GetComponent<PlayerMove>().OnStayClimb();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "effect") return;
        Debug.Log("Hello");
        body.GetComponent<PlayerMove>().OnHitClimb();
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "effect") return;
        // Debug.Log("Bye");
        body.GetComponent<PlayerMove>().OnLeaveClimb();
    }
}
