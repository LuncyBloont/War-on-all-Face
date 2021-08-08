using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realFire : MonoBehaviour
{
    public float fireLightAdd = 1;
    public float harm = 50;
    float maxLight;
    public GameObject lights;
    public float life = Mathf.Infinity;
    bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        maxLight = lights.GetComponent<Light>().intensity;
        lights.GetComponent<Light>().intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && lights.GetComponent<Light>().intensity < maxLight)
            lights.GetComponent<Light>().intensity += fireLightAdd * Time.deltaTime;
        if (active) life -= Time.deltaTime;
        
        if (!active && lights.GetComponent<Light>().intensity > fireLightAdd * Time.deltaTime)
        {
            lights.GetComponent<Light>().intensity -= fireLightAdd * Time.deltaTime;
        }
        else if (!active)
        {
            lights.GetComponent<Light>().intensity = 0;
        }
        if (life <= 0 && active)
        {
            GetComponent<ParticleSystem>().Stop();
            Destroy(GetComponent<SphereCollider>());
            active = false;
        }
    }
    private void OnTriggerStay(Collider other) {
        bottle bll;
        if (other.gameObject.TryGetComponent<bottle>(out bll))
        {
            if (bll.fireAble)
            {
                bll.life -= harm * Time.deltaTime /
                    Vector3.Distance(transform.position, other.gameObject.transform.position) * 3;
            }
        }
    }
}
