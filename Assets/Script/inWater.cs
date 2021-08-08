using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inWater : MonoBehaviour
{
    public int suc = 0;
    public float returnTime = 3;
    float ri = 0;
    public GameObject palyer;
    public GameObject eyeeffect;
    public Transform rePoint;
    // Start is called before the first frame update
    void Start()
    {
        eyeeffect.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ri >= returnTime)
        {
            ri = 0;
            palyer.transform.position = rePoint.position + new Vector3(0, 3, 0);
            palyer.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            eyeeffect.transform.localScale = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == "water")
        {
            // Debug.Log("Water");
            eyeeffect.transform.localScale = new Vector3(2, 1, 1);
            ri += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "water")
        {
            // Debug.Log("noWater");
            ri = 0;
            eyeeffect.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
