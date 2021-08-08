using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : MonoBehaviour
{
    public bool harmByBullet = true;
    public float hardness = 20;
    public bool fireAble = false;
    bool fireed = false;
    public bool fireOnWeek = true;
    public float onFireSubLife = 10;
    public float weekLife = 50;
    public GameObject fire;

    public bool selfDelete = true;
    public float boom = 0;
    public GameObject part1 = null, part2 = null, part3 = null, part4 = null, part5 = null, part6 = null;

    GameObject[] parts = new GameObject[6];

    public float life = 100;
    public Vector3 pos1, pos2, pos3, pos4, pos5, pos6;
    Vector3[] pos = new Vector3[6];

    float a;
    Rigidbody rd;
    Vector3 old_speed;
    // Start is called before the first frame update
    void Start()
    {
        parts[0] = part1; parts[1] = part2; parts[2] = part3;
        parts[3] = part4; parts[4] = part5; parts[5] = part6;
        pos[0] = pos1; pos[1] = pos2; pos[2] = pos3;
        pos[3] = pos4; pos[4] = pos5; pos[5] = pos6;
        old_speed = GetComponent<Rigidbody>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        rd = GetComponent<Rigidbody>();
        a = Vector3.Distance(rd.velocity, old_speed);
        old_speed = rd.velocity;

        if (life <= 0 || a > hardness)
        {
            mybreak(a, life);
        }

        if (!fireed && fireAble && fireOnWeek && life <= weekLife)
        {
            Instantiate(fire, transform).transform.parent = this.gameObject.transform;
            fireed = true;
        }
        if (fireAble && fireOnWeek && life <= weekLife)
        {
            life -= onFireSubLife * Time.deltaTime;
        }
    }
    public void mybreak(float speedOut, float damage) 
    {
        life -= damage;
        if (life > 0)
        {
            return;
        }
        if (selfDelete) Destroy(gameObject);

        lts_boom lbm;
        if (TryGetComponent<lts_boom>(out lbm))
        {
            lbm.boomStart();
        }

        int size = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i])
            {
                size++;
            }
        }
        for (int i = 0; i < parts.Length; i++)
        {
            if (!parts[i]) continue;
            Vector3 boomDirection = new Vector3(Random.Range(0, 10000) - 5000, Random.Range(0, 10000) - 5000, Random.Range(0, 10000) - 5000);
            boomDirection.Normalize();
            boomDirection = boomDirection * (speedOut + boom) / size;
            GameObject p = Instantiate(parts[i], transform.position + transform.rotation * pos[i], transform.rotation);
            Rigidbody rd;
            if (p.TryGetComponent<Rigidbody>(out rd))
            {
                rd.mass = GetComponent<Rigidbody>().mass / size;
                rd.velocity = rd.velocity + boomDirection;
                rd.angularVelocity = rd.angularVelocity + boomDirection * Random.Range(0, 1000) / 100;
            }
        }
    }
}
