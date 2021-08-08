using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0;
    public float life = 100;
    public GameObject self;
    float now = 0;
    public GameObject debug;

    public GameObject bulletHole;

    public float rand = 0.05f;

    public Vector3 oldPos = new Vector3(0, 0, 0);

    void Start()
    {
        oldPos = transform.position;
        transform.forward = transform.forward + 
            (transform.right * rand * (Random.Range(0, 100) - 50) / 100) + 
            (transform.up * rand * (Random.Range(0, 100) - 50) / 100);
    }

    // Update is called once per frame
    void Update()
    {
        now += Time.deltaTime;
        if (now >= life)
        {
            Destroy(gameObject); 
        }


        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Ray pathAway = new Ray(oldPos, transform.position - oldPos);
        RaycastHit hit;
        // Physics.Raycast(pathAway, out hit, speed * Time.deltaTime, 1<<LayerMask.NameToLayer("Default"))
        if (Physics.Raycast(pathAway, out hit, speed * Time.deltaTime * 1.1f,
            1 << LayerMask.NameToLayer("Default") | 1 << LayerMask.NameToLayer("fireCreator"),
            QueryTriggerInteraction.Ignore))
        {
            GameObject bulBoom =  Instantiate(bulletHole, hit.point, transform.rotation);
            bulBoom.transform.forward = hit.normal;
            bulBoom.transform.parent = hit.collider.gameObject.transform;
            bulBoom.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;


            bulletHit bh = bulBoom.AddComponent<bulletHit>();
            bh.direction = transform.forward;
            bh.toObj = hit.collider.gameObject;


            Destroy(gameObject);
        }
        oldPos = transform.position;


    }
    private void OnCollisionEnter(Collision other) {
        // Instantiate(debug, other.GetContact(0).point, transform.rotation);
    }
}
