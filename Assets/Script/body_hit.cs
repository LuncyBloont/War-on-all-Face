using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body_hit : MonoBehaviour
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
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "effect") return;
        body.GetComponent<MoveAble>().OnHitWall();
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == "effect") return;
        body.GetComponent<MoveAble>().OnStayWall();
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "effect") return;
        body.GetComponent<MoveAble>().OnLeaveWall();
    }
}
