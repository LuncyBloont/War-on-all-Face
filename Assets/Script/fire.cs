using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject abullet;
    public GameObject debug;

    public GameObject body;

    public GameObject eye;
    public GameObject bulH;
    public Transform gun;
    public float far = 2f;

    public float backForce = 2;

    public float walkEffect = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fire()
    {
        GameObject nb = Instantiate(abullet, gun.position + gun.forward * far, gun.rotation);
        bullet scriptB = nb.AddComponent<bullet>() as bullet;
        scriptB.speed = 900;
        scriptB.life = 34;
        scriptB.rand = Vector3.Distance(body.GetComponent<Rigidbody>().velocity, new Vector3(0, 0, 0)) *
            walkEffect + (1 - walkEffect) * scriptB.rand;
        scriptB.debug = debug;
        scriptB.bulletHole = bulH;

        eye.GetComponent<eyeUD>().upE = backForce;
        // BoxCollider bc = nb.AddComponent<BoxCollider>() as BoxCollider;
        // bc.isTrigger = true;
        // bc.size = new Vector3(bc.size.x, bc.size.y, scriptB.speed * Time.deltaTime);
        // bc.center = new Vector3(0, 0, scriptB.speed / 2 * Time.deltaTime);
        // Rigidbody rd = nb.AddComponent<Rigidbody>() as Rigidbody;
        // rd.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        /* rd.constraints = RigidbodyConstraints.FreezePositionX | 
            RigidbodyConstraints.FreezePositionY | 
                RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
        */
    }
    
}
