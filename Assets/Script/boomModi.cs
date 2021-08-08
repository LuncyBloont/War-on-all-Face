using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomModi : MonoBehaviour
{
    public float life = 1;
    public float force = 100;

    public float forceLimit = 100;
    public GameObject mainFire;
    float lifei = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject mf = Instantiate(mainFire, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        lifei += Time.deltaTime;
        if (lifei > life)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == "effect") return;
        Rigidbody rb;
        bottle bll;
        if (other.gameObject.TryGetComponent<Rigidbody>(out rb))
        {
            float ff = force / 4 / Vector3.Distance(other.gameObject.transform.position, transform.position);
            ff = ff > forceLimit ? forceLimit * 100 : ff * 100;
            rb.AddForce((other.gameObject.transform.position - transform.position).normalized * ff);
        }
        if (other.gameObject.TryGetComponent<bottle>(out bll))
        {
            bll.life -= force / 12 / Vector3.Distance(other.gameObject.transform.position, transform.position);
        }
    }
}
