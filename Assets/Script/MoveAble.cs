using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAble : MonoBehaviour
{
    Rigidbody rb;

    public GameObject eye;
    Vector3 eye_spos;
    public GameObject mainBody;
    public float ctrlSpeed = 6;
    public float ctrlForce = 0.1f;
    public bool superIng = false;
    public bool hitWall = false;
    public float maxSpeed = 6;
    public float superSpeed = 12;
    public float goForce = 200;
    public float turnRate = 0.1f;
    public float airLost = 0.9f;
    public bool onFloor = true;
    public bool headCover = false;
    public float jumpSpeed = 15;
    public float climbSpeed = 0.6f;
    public float f = 0.1f;
    public float ctrlRate = 0.65f;
    float ctrlNow = 1;

    public Vector3 forceAdd;


    bool moving = false;
    void Start() {
        rb = GetComponent<Rigidbody>();
        eye_spos = eye.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        moving = false;
        forceAdd = new Vector3(0, 0, 0);
        float realMaxSpeed = maxSpeed;
        if (Input.GetKey(KeyCode.W))
        {
            forceAdd += transform.forward;
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            forceAdd -= transform.right;
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            forceAdd -= transform.forward;
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            forceAdd += transform.right;
            moving = true;
        }

        // ---------------------蹲下-------------------------
        // Debug.Log(ctrlNow);
        float ctrlTo = 1;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            headCover = false;
            ctrlTo = ctrlRate;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            ctrlTo = 1;
        }
        mainBody.transform.localScale = new Vector3(
            mainBody.transform.localScale.x,
            ctrlNow,
            mainBody.transform.localScale.z
        );
        eye.transform.localPosition = new Vector3(eye_spos.x, eye_spos.y * ctrlNow, eye_spos.z);
        if (Mathf.Abs(ctrlNow - ctrlTo) > ctrlForce * Time.deltaTime)
        {
            if ((ctrlNow < ctrlTo && !headCover) || ctrlNow > ctrlTo)
            {
                ctrlNow += (ctrlTo - ctrlNow > 0 ? 1 : ctrlTo - ctrlNow < 0 ? -1 : 0) * ctrlForce * Time.deltaTime;
            }
            else
            {
                // ctrlNow -= (ctrlTo - ctrlNow > 0 ? 1 : ctrlTo - ctrlNow < 0 ? -1 : 0) * ctrlForce * Time.deltaTime;
            }
        }
        else
        {
            ctrlNow = ctrlTo;
        }
        realMaxSpeed = ctrlSpeed + (realMaxSpeed - ctrlSpeed) * (ctrlNow - ctrlRate) / (1 - ctrlRate);
        // --------------------------------------------------

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            realMaxSpeed *= superSpeed / maxSpeed;
            superIng = true;
        }
        else
        {
            superIng = false;
        }
        forceAdd.Normalize();
        if ((Vector3.Dot(forceAdd.normalized, rb.velocity) * turnRate + 
            Vector3.Distance(new Vector3(0, 0, 0), rb.velocity) * (1 - turnRate)) < 
            (onFloor ? realMaxSpeed : realMaxSpeed - realMaxSpeed * airLost))
        {
            float realGoForce = onFloor ? goForce : goForce - goForce * airLost;
            rb.AddForce(forceAdd.normalized * realGoForce * rb.mass);
        }
        if (onFloor)
        {
            if (Vector3.Distance(new Vector3(0, rb.velocity.y, 0), rb.velocity) > f * Time.deltaTime)
            {
                Vector3 vvv = new Vector3(
                    rb.velocity.x,
                    0,
                    rb.velocity.z
                );
                vvv.Normalize();
                rb.velocity = rb.velocity - vvv * f * Time.deltaTime;
            }
            else
            {
                rb.velocity = new Vector3(
                    0, rb.velocity.y, 0
                );
            }

        
            // rb.velocity *= Mathf.Pow(1 - f, Time.deltaTime * 20);
            if (Input.GetKeyDown(KeyCode.Space) &&
                 Vector3.Dot(transform.up, rb.velocity) < jumpSpeed)
            {
                rb.velocity += new Vector3(0, jumpSpeed - Vector3.Dot(transform.up, rb.velocity), 0);
            }
        }
        
    }
    public void willClimb(Collider other)
    {
        // float dis = Vector3.Distance(new Vector3(transform.position.x, other.GetContact(0).point.y, transform.position.z), 
            // other.GetContact(0).point);
        float _speed = climbSpeed; 
        if (superIng)
        {
            _speed = climbSpeed * superSpeed / maxSpeed;
        }
        if (!hitWall && moving)
        {
            if (rb.velocity.y < climbSpeed)
                rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
        }
    }
    
    public void OnHitFloor()
    {
        onFloor = true;
    }
    public void OnStayFloor()
    {
        onFloor = true;
    }
        public void OnLeaveFloor()
    {
        onFloor = false;
    }
    public void OnHitWall()
    {
        hitWall = true;
    }
    public void OnStayWall()
    {
        hitWall = true;
    }
        public void OnLeaveWall()
    {
        hitWall = false;
    }
}
