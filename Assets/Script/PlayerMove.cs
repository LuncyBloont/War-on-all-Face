using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /*float speedW = 0;
    float speedA = 0;
    float speedS = 0;
    float speedD = 0;*/
    // float speedJump = 0;

    public GameObject debug;
    public float jumpLost = 0.7f;
    public float jumpSpeed = 8;

    

    public float climbSpeed = 2;
    // public float 


    public float FSpeed = 0.6f;
    public float airSpeed = 0.6f;


    public float f = 2;
    // public float jumpFOnWall = 0.2f;

    CapsuleCollider cc_ctrl;

    float cc_ctr = 0; //, cc_hei = 2;
    public float cc_back_speed = 0.04f;

    public bool move_able = false;
    bool old_move_able = false;

   

    // bool walling = false;
    // Start is called before the first frame update
    void Start()
    {
        cc_ctrl = GetComponent<CapsuleCollider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.maxDepenetrationVelocity = 100;
        move_able = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 moveSpeed = new Vector3(0, 0, 0);
        /*
        if (speedW < 0) speedW = 0;
        if (speedA < 0) speedA = 0;
        if (speedS < 0) speedS = 0;
        if (speedD < 0) speedD = 0;
        if (speedW > maxSpeed) speedW = maxSpeed;
        if (speedA > maxSpeed) speedA = maxSpeed;
        if (speedS > maxSpeed) speedS = maxSpeed;
        if (speedD > maxSpeed) speedD = maxSpeed;*/
        // if (speedJump > jumpSpeed) speedJump = jumpSpeed;

        /*if (Input.GetKey("w"))
        {
            speedW += f * Time.deltaTime * 2 * airSpeed;
        }
        if (Input.GetKey("a"))
        {
            speedA += f * Time.deltaTime * 2 * airSpeed;
        }
        if (Input.GetKey("s"))
        {
            speedS += f * Time.deltaTime * 2 * airSpeed;
        }
        if (Input.GetKey("d"))
        {
            speedD += f * Time.deltaTime * 2 * airSpeed;
        }*/

        if (Input.GetKey("w"))
        {
            moveSpeed = moveSpeed + transform.forward;
        }
        if (Input.GetKey("a"))
        {
            moveSpeed = moveSpeed - transform.right;
        }
        if (Input.GetKey("s"))
        {
            moveSpeed = moveSpeed - transform.forward;
        }
        if (Input.GetKey("d"))
        {
            moveSpeed = moveSpeed + transform.right;
        }
        

        //move_able = false;


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            cc_ctr = 0.5f;
            // cc_hei = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            cc_ctr = 0;
            // cc_hei = 2;
        }

        // transform.Translate(Vector3.forward * Time.deltaTime * speedW);
        // transform.Translate(Vector3.left * Time.deltaTime * speedA);
        // transform.Translate(Vector3.back * Time.deltaTime * speedS);
        // transform.Translate(Vector3.right * Time.deltaTime * speedD);
        // transform.Translate(Vector3.up * Time.deltaTime * speedJump);
        //Debug.Log("~");
        

        float FAspeed;

        if (move_able)
        {
            // speedW -= f * Time.deltaTime;
            // speedA -= f * Time.deltaTime;
            // speedS -= f * Time.deltaTime;
            // speedD -= f * Time.deltaTime;
            float FF = Vector3.Distance(new Vector3(rb.velocity.x, 0, rb.velocity.z), new Vector3(0, 0, 0));
            if (FF > 0)
            {
                float sub = Mathf.Pow((1 - f), Time.deltaTime);
                rb.velocity = new Vector3(rb.velocity.x * sub, rb.velocity.y, rb.velocity.z * sub);
            }
            if (Input.GetKeyDown("space"))
            {
                // speedJump = jumpSpeed;
                // jumpTimeI = 0;
                // Rigidbody rb = GetComponent<Rigidbody>();
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed > rb.velocity.y ? rb.velocity.y + jumpSpeed : rb.velocity.y, rb.velocity.z);
            }

            FAspeed = FSpeed;
        }
        else
        {
            FAspeed = airSpeed;
        }
        float mxLimit = FAspeed * Time.deltaTime;

        
        rb.velocity += moveSpeed.normalized * FAspeed / 10;
        // Debug.Log(Vector3.Distance(new Vector3(rb.velocity.x, 0, rb.velocity.z), new Vector3(0, 0, 0)));

        if (move_able != old_move_able)
        {
            rb.velocity = new Vector3(rb.velocity.x * (1 - jumpLost), rb.velocity.y, rb.velocity.z * (1 - jumpLost));
        }

        old_move_able = move_able;
        
        cc_ctrl.center = new Vector3(cc_ctrl.center.x, cc_ctrl.center.y + (cc_ctr - cc_ctrl.center.y) * cc_back_speed, cc_ctrl.center.z);
        // cc_ctrl.size.y = cc_ctrl.height + (cc_hei - cc_ctrl.height) * cc_back_speed;
    }
    public void OnHitFloor()
    {
        // speedJump = 0;
        move_able = true;
        // jumpTimeI = jumpTime;
    }
    public void OnStayFloor()
    {
        // speedJump = 0;
        move_able = true;
        // jumpTimeI = jumpTime;
    }
    public void OnLeaveFloor()
    {
        move_able = false;
    }
    public void OnHitClimb()
    {
        if (!move_able) return;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed + rb.velocity.y, rb.velocity.z);
    }
    public void OnStayClimb()
    {
        if (!move_able) return;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed + rb.velocity.y, rb.velocity.z);
    }
    public void OnLeaveClimb()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        // OnHitClimb();
        // other.GetContact(0).point;
        // Instantiate(debug, other.GetContact(0).point, transform.rotation);
    }
    private void OnCollisionStay(Collision other) 
    {
        // OnStayClimb();
    }
}
