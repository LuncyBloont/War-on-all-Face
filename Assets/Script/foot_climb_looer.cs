using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot_climb_looer : MonoBehaviour
{
    public GameObject body;
    public GameObject mainbody;

    Vector3 spos;
    float sscale;
    // Start is called before the first frame update
    void Start()
    {
        spos = transform.position - mainbody.transform.position;
        sscale = mainbody.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainbody.transform.position + 
            new Vector3(spos.x, spos.y * mainbody.transform.localScale.y / sscale, spos.z) + 
            new Vector3(body.GetComponent<MoveAble>().forceAdd.normalized.x,
            0, body.GetComponent<MoveAble>().forceAdd.normalized.z) / 2;
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == "effect" || other.tag == "water") return;
        body.GetComponent<MoveAble>().willClimb(other);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "effect" || other.tag == "water") return;
        body.GetComponent<MoveAble>().willClimb(other);
    }
}
