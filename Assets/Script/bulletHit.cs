using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    // Start is called before the first frame update
    public float size = 0.4f;
    public float force = 6900;

    public float damage = 90;

    public Vector3 direction = Vector3.up;
    public float life = 5;

    float lifei = 0;
    public GameObject toObj = null;
    Rigidbody tord = null;
    void Start()
    {
        // SphereCollider sc = gameObject.AddComponent<SphereCollider>();
        // sc.radius = size;
        // sc.isTrigger = true;
        lifei = 0;


        
        bottle btll;
        if (toObj.TryGetComponent<Rigidbody>(out tord))
        {
            // Vector3 toForce = force / Vector3.Distance(other.gameObject.transform.position, transform.position) *
                // (other.gameObject.transform.position - transform.position);
            // Debug.Log(Vector3.Distance(toForceSpeed, new Vector3(0, 0, 0)));
            // tord.velocity = tord.velocity + toForceSpeed;
            tord.AddForceAtPosition(direction * force, transform.position);
        }
        if (toObj.TryGetComponent<bottle>(out btll))
        {
            if (btll.harmByBullet)
                btll.mybreak(force * Time.deltaTime / toObj.GetComponent<Rigidbody>().mass, damage);
        }
        // Destroy(gameObject.GetComponent<SphereCollider>());
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

    private void OnTriggerEnter(Collider other) {
        
    }
}
